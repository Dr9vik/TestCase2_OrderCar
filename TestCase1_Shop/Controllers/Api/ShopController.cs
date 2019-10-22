using Business_Logic_Layer.Common.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace TestCase1_Shop.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/shop")]
    [ApiController]
    public class ShopController : Controller
    {
        private readonly IUserService _db;

        public ShopController(IUserService db)
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
    }
}
