using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SombraSoft.MovieRental.MongoDB.Collections
{
    public abstract class BaseCollection
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime? CreatedOn { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime? UpdatedOn { get; set; }
    }
}
