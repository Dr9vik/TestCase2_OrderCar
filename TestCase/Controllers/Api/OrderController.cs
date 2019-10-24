using Business_Logic_Layer.Common.Model;
using Business_Logic_Layer.Common.Model.ModelFilter;
using Business_Logic_Layer.Common.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCase1_Shop.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/order")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderService _db;

        public OrderController(IOrderService db)
        {
            _db = db;
        }

        [HttpGet, Route("")]
        [ProducesResponseType(typeof(IList<OrderBL>), 200)]
        public async Task<IActionResult> FindAll()
        {
            return Ok(await _db.FindAll());
        }
        [HttpGet, Route("filter")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> FindAll([FromQuery]OrderBLFilter filter)
        {
            return Ok(await _db.FindAll(filter));
        }

        [HttpPost, Route("create")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Create(OrderBLCreate item)
        {
            return Ok(await _db.Create(item));
        }

        [HttpPost, Route("update")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Update(OrderBLUpdate item)
        {
            return Ok(await _db.Update(item));
        }

        [HttpPost, Route("delete/{id}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _db.Delete(id));
        }
    }
}
