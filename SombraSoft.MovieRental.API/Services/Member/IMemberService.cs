using System.Collections.Generic;
using System.Threading.Tasks;
using SombraSoft.MovieRental.MongoDB.DTO;

namespace SombraSoft.MovieRental.API.Services.Member
{
    public interface IMemberService : IBaseService<MongoDB.Collections.Member>
    {
        Task<IEnumerable<MemberSummary>> GetMemberSummariesAsync(int takeCount = int.MaxValue);
    }
}
