using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SombraSoft.MovieRental.MongoDB.Collections;

namespace SombraSoft.MovieRental.MongoDB.Repositories
{
    public interface IBaseRepository<T> where T : BaseCollection
    {
        Task<bool> CollectionExistsAsync();
        Task<IEnumerable<T>> GetAsync(CancellationToken token);
        Task<T> GetAsync(string id);
        Task<T> CreateAsync(T doc);
        Task<IEnumerable<T>> CreateManyAsync(IEnumerable<T> docs);
        Task UpdateAsync(string id, T docIn);
        Task RemoveAsync(string id);
    }
}
