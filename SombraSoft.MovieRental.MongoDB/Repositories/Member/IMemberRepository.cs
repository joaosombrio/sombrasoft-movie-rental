using System.Collections.Generic;
using System.Threading.Tasks;
using SombraSoft.MovieRental.MongoDB.DTO;

namespace SombraSoft.MovieRental.MongoDB.Repositories.Member
{
    public interface IMemberRepository : IBaseRepository<Collections.Member>
    {
        Task<List<MemberSummary>> GetMemberSummariesAsync(int takeCount = int.MaxValue);
    }
}
