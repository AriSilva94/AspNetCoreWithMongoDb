using AspNetCoreWithMongoDb.Models.Context.Interface;
using MongoDB.Driver;
using System;

namespace AspNetCoreWithMongoDb.Models.Context
{
    public class BookstoreDatabaseSettings : IBookstoreDatabaseSettings
    {
        public string BooksCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
