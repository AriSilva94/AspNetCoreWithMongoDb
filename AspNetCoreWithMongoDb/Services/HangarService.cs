using AspNetCoreWithMongoDb.Models;
using AspNetCoreWithMongoDb.Models.Context.Interface;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreWithMongoDb.Services
{
    public class HangarService
    {
        private readonly IMongoCollection<Hangar> _hangar;

        public HangarService(IBookstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _hangar = database.GetCollection<Hangar>(settings.BooksCollectionName);
        }

        public List<Hangar> Get() =>
            _hangar.Find(hangar => true).ToList();

        public Hangar Get(string id) =>
            _hangar.Find<Hangar>(hangar => hangar.Id == id).FirstOrDefault();

        public Hangar Create(Hangar hangar)
        {
            _hangar.InsertOne(hangar);

            return hangar;
        }

        public void Update(string id, Hangar hangarIn) =>
            _hangar.ReplaceOne(hangar => hangar.Id == id, hangarIn);

        public void Remove(Hangar hangarIn) =>
            _hangar.DeleteOne(hangar => hangar.Id == hangarIn.Id);

        public void Remove(string id) =>
            _hangar.DeleteOne(hangar => hangar.Id == id);
    }
}
