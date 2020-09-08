using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SombraSoft.MovieRental.MongoDB.Collections;

namespace SombraSoft.MovieRental.API.Services
{
    public interface IBaseService<T> where T : BaseCollection
    {
        Task<IEnumerable<T>> GetAsync(CancellationToken token);
        Task<T> GetAsync(string id);
        Task<T> CreateAsync(T doc);
        Task<T> UpdateAsync(string id, T docIn);
        Task RemoveAsync(string id);
    }
}
