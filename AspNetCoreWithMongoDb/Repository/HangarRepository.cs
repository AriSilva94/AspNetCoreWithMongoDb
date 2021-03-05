using AspNetCoreWithMongoDb.Models;
using AspNetCoreWithMongoDb.Models.Context.Interface;
using AspNetCoreWithMongoDb.Repository.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;

namespace AspNetCoreWithMongoDb.Repository
{
    public class HangarRepository : IHangarRepository
    {
        private readonly IMongoCollection<Hangar> _hangar;

        public HangarRepository(IBookstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _hangar = database.GetCollection<Hangar>(settings.BooksCollectionName);
        }

        public List<Hangar> Get()
        {
            return _hangar.Find(hangar => true).ToList();
        }

        public Hangar Get(string id)
        {
            return _hangar.Find(hangar => hangar.Id.Equals(id)).FirstOrDefault();
        }
        public Hangar Create(Hangar hangar)
        {
            _hangar.InsertOne(hangar);

            return hangar;
        }

        public void Update(string id, Hangar hangarIn)
        {
            _hangar.ReplaceOne(hangar => hangar.Id == id, hangarIn);
        }

        public void Remove(string id)
        {
            _hangar.DeleteOne(hangar => hangar.Id == id);
        }
    }
}
