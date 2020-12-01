using System;
using API.Data.Collection;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace API.Data
{
    public class MongoDb
    {
        public IMongoDatabase Db { get; }
        private string _dbUsername;
        private string _dbPassword;

        public MongoDb(IConfiguration configuration)
        {
            try
            {
                _dbUsername = configuration["dbUsername"];
                _dbPassword = configuration["dbPassword"];
                
                var connectionString =
                    $"mongodb+srv://{_dbUsername}:{_dbPassword}@cluster0.axk4f.mongodb.net/test?retryWrites=" +
                    $"true&w=majority";
                
                var settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
                var client = new MongoClient(settings);
                Db = client.GetDatabase(configuration["DbName"]);
                MapClasses();
            }
            catch (Exception ex)
            {
                throw new MongoException("It was not possible to connect to MongoDB", ex);
            }
        }

        private void MapClasses()
        {
            var conventionPack = new ConventionPack {new CamelCaseElementNameConvention()};
            ConventionRegistry.Register("camelCase", conventionPack, x => true);

            if (!BsonClassMap.IsClassMapRegistered(typeof(Infected)))
            {
                BsonClassMap.RegisterClassMap<Infected>(x =>
                {
                    x.AutoMap();
                    x.SetIgnoreExtraElements(true);
                });
            }
        }
    }
}