using SombraSoft.MovieRental.MongoDB.Repositories.Purchase;

namespace SombraSoft.MovieRental.API.Services.Purchase
{
    public class PurchaseService : BaseService<MongoDB.Collections.Purchase, IPurchaseRepository>, IPurchaseService
    {
        public PurchaseService(IPurchaseRepository purchaseRepository) : base(purchaseRepository) { }
    }
}
