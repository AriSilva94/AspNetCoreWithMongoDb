using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreWithMongoDb.Models
{
    public class Hangar
    {
        [BsonId]
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public List<string> Programs { get; set; }
    }
}
