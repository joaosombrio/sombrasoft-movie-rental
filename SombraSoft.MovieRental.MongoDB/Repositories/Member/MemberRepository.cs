using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using SombraSoft.MovieRental.MongoDB.DTO;

namespace SombraSoft.MovieRental.MongoDB.Repositories.Member
{
    public class MemberRepository : BaseRepository<Collections.Member>, IMemberRepository
    {
        public MemberRepository(IMovieRentalDatabaseSettings dbSettings) : base(dbSettings) { }

        public async Task<List<MemberSummary>> GetMemberSummariesAsync(int takeCount = int.MaxValue)
        {
            var purchaseCollection = _database.GetCollection<Collections.Purchase>(nameof(Collections.Purchase));

            var query = purchaseCollection.AsQueryable()
                .GroupBy(p => p.MemberId)
                .Select(purchaseGroup => new MemberSummary
                {
                    MemberId = purchaseGroup.First().MemberId,
                    TotalSpent = purchaseGroup.Sum(p => p.TotalCost),
                    TotalRentals = purchaseGroup.Sum(p => p.MovieIds.Count())
                })
                .Join(_collection.AsQueryable(), memberSummary => memberSummary.MemberId, m => m.Id,
                    (memberSummary, member) => new MemberSummary
                    {
                        TotalRentals = memberSummary.TotalRentals,
                        TotalSpent = memberSummary.TotalSpent,
                        MemberFullName = member.FullName,
                        MemberId = member.Id
                    }).OrderByDescending(m => m.TotalRentals);

            return await query.ToListAsync();
        }
    }
}
