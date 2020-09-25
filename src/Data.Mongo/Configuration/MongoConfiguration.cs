using Core.Domain;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using System;

namespace Data.Mongo
{
    public class MongoConfiguration
    {
        public static void Configure()
        {
            BsonSerializer.RegisterIdGenerator(typeof(Guid), CombGuidGenerator.Instance);
            BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;

            BsonClassMap.RegisterClassMap<Article>(c =>
            {
                c.AutoMap();
                c.SetIdMember(c.GetMemberMap(p => p.Id));
            });
        }
    }
}