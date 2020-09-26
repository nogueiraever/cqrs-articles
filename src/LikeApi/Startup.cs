using Core;
using Data.Mongo;
using IoC;
using IoC.Extensions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO.Compression;

namespace LikeApi
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseCors(builder => builder
                 .AllowAnyOrigin()
                 .AllowAnyMethod()
                 .AllowAnyHeader());

            app.UseMvc();
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddResponseCompression();
            services.Configure<BrotliCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Fastest;
            });

            var assemblyApplication = AppDomain.CurrentDomain.Load("Core");
            services.AddMediatR(assemblyApplication);

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
                options.Filters.Add(new GlobalExceptionFilter());
            })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.RegisterDependencies();

            var messagingConfiguration = configuration.GetSection(nameof(Messaging)).Get<Messaging>();

            services.Configure<Messaging>(c =>
            {
                c.Exchanges = messagingConfiguration.Exchanges;
                c.Queues = messagingConfiguration.Queues;
            });

            var rabbitMQConfiguration = configuration.GetSection(nameof(RabbitMQConfiguration)).Get<RabbitMQConfiguration>();

            _ = services.Configure<RabbitMQConfiguration>(c =>
            {
                c.Hostname = rabbitMQConfiguration.Hostname;
                c.Username = rabbitMQConfiguration.Username;
                c.Password = rabbitMQConfiguration.Password;
            });

            services.AddRabbit(messagingConfiguration, rabbitMQConfiguration);

            //MockData
            CreateMockedData(services);
        }

        private static void CreateMockedData(IServiceCollection services)
        {
            var mongoRepository = services.BuildServiceProvider().GetRequiredService<IArticlesMongoRepository>();
            var articleId = Guid.Parse("2ae90450-9040-4f3d-900b-cd7565a1225c");
            var mockArticle = mongoRepository.GetById(articleId).Result;
            if (mockArticle == null)
            {
                mockArticle = new Core.Domain.Article()
                {
                    Id = articleId,
                    Description = "Example description"
                };
                mongoRepository.Save(mockArticle);
            }
        }
    }
}