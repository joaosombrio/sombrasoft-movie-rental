using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SombraSoft.MovieRental.MongoDB.Collections;
using SombraSoft.MovieRental.MongoDB.Repositories;

namespace SombraSoft.MovieRental.API.Services
{
    public class BaseService<T, TU> : IBaseService<T>
        where T : BaseCollection
        where TU : IBaseRepository<T>
    {
        protected readonly TU Repository;
        public BaseService(TU repository)
        {
            Repository = repository;
        }

        public async Task<IEnumerable<T>> GetAsync(CancellationToken token) => await Repository.GetAsync(token);

        public async Task<T> GetAsync(string id) => await Repository.GetAsync(id);

        public async Task<T> CreateAsync(T doc) => await Repository.CreateAsync(doc);

        public async Task<T> UpdateAsync(string id, T docIn)
        {
            await Repository.UpdateAsync(id, docIn);
            return await Repository.GetAsync(id);
        }

        public async Task RemoveAsync(string id) => await Repository.RemoveAsync(id);
    }
}
