using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SombraSoft.MovieRental.API.Services.Purchase;
using SombraSoft.MovieRental.MongoDB.Collections;

namespace SombraSoft.MovieRental.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PurchasesController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;

        public PurchasesController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        [HttpGet]
        public async Task<IEnumerable<Purchase>> Get(CancellationToken token)
        {
            return await _purchaseService.GetAsync(token);
        }

        [HttpGet("{id}")]
        public async Task<Purchase> Get(string id)
        {
            return await _purchaseService.GetAsync(id);
        }

        [HttpPost]
        public async Task<Purchase> Create(Purchase purchase)
        {
            return await _purchaseService.CreateAsync(purchase);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Purchase purchase)
        {
            await _purchaseService.UpdateAsync(id, purchase);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _purchaseService.RemoveAsync(id);
            return Ok();
        }
    }
}
