using Business_Logic_Layer.Common.Model;
using Business_Logic_Layer.Common.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace TestCase1_Shop.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/storeproduct")]
    [ApiController]
    public class StoreProductController : Controller
    {
        private readonly IOrderService _db;

        public StoreProductController(IOrderService db)
        {
            _db = db;
        }

        [HttpGet, Route("{id}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> FindAllProductInShop(Guid id)
        {
            return Ok(await _db.FindAllProductInShop(id));
        }
        [HttpGet, Route("{id}/productnotinshop")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> FindAllProductNotInShop(Guid id)
        {
            return Ok(await _db.FindAllProductNotInShop(id));
        }
        [HttpPost, Route("addproduct")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> AddProduct(ShopSPBL item)
        {
            return Ok(await _db.AddProduct(item));
        }
        [HttpPost, Route("delete/{id}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _db.Delete(id));
        }
    }
}
