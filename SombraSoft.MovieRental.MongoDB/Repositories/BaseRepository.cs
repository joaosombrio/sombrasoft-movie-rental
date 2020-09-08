using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using SombraSoft.MovieRental.MongoDB.Collections;

namespace SombraSoft.MovieRental.MongoDB.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseCollection
    {
        protected readonly IMongoCollection<T> _collection;
        protected readonly IMongoDatabase _database;

        protected BaseRepository(IMovieRentalDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _database = client.GetDatabase(settings.DatabaseName);

            _collection = _database.GetCollection<T>(typeof(T).Name);
        }

        public async Task<bool> CollectionExistsAsync()
        {
            var dbNames = await _database.ListCollectionNamesAsync();
            return dbNames.ToList().Any(db => db == typeof(T).Name);
        }

        public async Task<IEnumerable<T>> GetAsync(CancellationToken token)
        {
            var sort = Builders<T>.Sort.Descending(e => e.UpdatedOn);
            var cursor = await _collection.FindAsync(doc => true, new FindOptions<T, T>{ Sort = sort }, cancellationToken: token);
            return await cursor.ToListAsync(token);
        }

        public async Task<T> GetAsync(string id)
        {
            var cursor = await _collection.FindAsync(doc => doc.Id == id);
            return await cursor.FirstOrDefaultAsync();
        }

        public async Task<T> CreateAsync(T doc)
        {
            doc.Id = ObjectId.GenerateNewId().ToString();
            doc.CreatedOn ??= DateTime.Now;
            doc.UpdatedOn ??= DateTime.Now;

            await _collection.InsertOneAsync(doc);
            return doc;
        }

        public async Task<IEnumerable<T>> CreateManyAsync(IEnumerable<T> docs)
        {
            foreach (var doc in docs)
            {
                doc.Id = ObjectId.GenerateNewId().ToString();
                doc.CreatedOn ??= DateTime.Now;
                doc.UpdatedOn ??= DateTime.Now;
            }

            await _collection.InsertManyAsync(docs);
            return docs;
        }

        public async Task UpdateAsync(string id, T docIn)
        {
            docIn.UpdatedOn = DateTime.Now;
            await _collection.ReplaceOneAsync(doc => doc.Id == id, docIn);
        }

        public Task RemoveAsync(string id) =>
            _collection.DeleteOneAsync(doc => doc.Id == id);
    }
}
