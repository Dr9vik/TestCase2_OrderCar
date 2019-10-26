using Business_Logic_Layer.Common.Model;
using Business_Logic_Layer.Common.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace TestCase1_Shop.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _db;

        public UserController(IUserService db)
        {
            _db = db;
        }

        [HttpGet, Route("")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _db.FindAll<UserBLCL>());
        }
        [HttpGet, Route("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _db.FindById<UserBLCL>(id);
            if (item == null)
                return BadRequest(id);
            return Ok(item);
        }
    }
}
