using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SombraSoft.MovieRental.MongoDB.Collections
{
    public class Movie : BaseCollection
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public IEnumerable<string> Genres { get; set; }
        public int Runtime { get; set; }
        public string Director { get; set; }
        public IEnumerable<string> Writers { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> Actors { get; set; }
        public double Rating { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime ReleaseDate { get; set; }
        public int RentalDuration { get; set; }
        public decimal RentalCost { get; set; }
    }
}
