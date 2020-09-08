using System.Collections.Generic;
using System.Threading.Tasks;
using SombraSoft.MovieRental.MongoDB.DTO;
using SombraSoft.MovieRental.MongoDB.Repositories.Member;

namespace SombraSoft.MovieRental.API.Services.Member
{
    public class MemberService : BaseService<MongoDB.Collections.Member, IMemberRepository>, IMemberService
    {
        public MemberService(IMemberRepository memberRepository) : base(memberRepository) { }

        public async Task<IEnumerable<MemberSummary>> GetMemberSummariesAsync(int takeCount = int.MaxValue)
        {
            return await Repository.GetMemberSummariesAsync(takeCount);
        }
    }
}
