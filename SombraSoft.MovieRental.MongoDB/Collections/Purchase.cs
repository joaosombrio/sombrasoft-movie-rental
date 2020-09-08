using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SombraSoft.MovieRental.MongoDB.Collections
{
    public class Purchase : BaseCollection
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string MemberId { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public IEnumerable<string> MovieIds { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime RentalDate { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime RentalExpiry { get; set; }
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal TotalCost { get; set; }
    }
}
