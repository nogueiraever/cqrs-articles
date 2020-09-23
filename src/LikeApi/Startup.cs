using Core.Configurations;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddResponseCompression();
            services.Configure<BrotliCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Fastest;
            });

            var assemblyAplicao = AppDomain.CurrentDomain.Load("Core");
            services.AddMediatR(assemblyAplicao);

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = true;
                options.Filters.Add(new GlobalExceptionFilter());
            })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            var awsConfiguration = configuration.GetSection(nameof(Aws)).Get<Aws>();

            services.Configure<Aws>(c =>
            {
                c.AccessKeyId = awsConfiguration.AccessKeyId;
                c.SecretAccessKey = awsConfiguration.SecretAccessKey;
                c.Queues = awsConfiguration.Queues;
                c.Region = awsConfiguration.Region;
            });
        }
    }
}