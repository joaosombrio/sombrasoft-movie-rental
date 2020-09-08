namespace SombraSoft.MovieRental.MongoDB.Repositories.Purchase
{
    public class PurchaseRepository : BaseRepository<Collections.Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(IMovieRentalDatabaseSettings settings) : base(settings)
        {
            
        }
    }
}
