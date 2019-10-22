using Business_Logic_Layer.Common.Model;
using Business_Logic_Layer.Common.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCase1_Shop.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/product")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly ICarService _db;

        public ProductController(ICarService db)
        {
            _db = db;
        }

        [HttpGet, Route("")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _db.FindAll());
        }
        [HttpGet, Route("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _db.FindById(id);
            if (item == null)
                return BadRequest(id);
            return Ok(item);
        }
        [HttpPost, Route("update")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Update(ProductBLUpdate item)
        {
            return Ok(await _db.Update(item));
        }
    }
}
