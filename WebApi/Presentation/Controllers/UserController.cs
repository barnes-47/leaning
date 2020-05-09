using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebApi.Business.Contracts;
using WebApi.Infrastructure.Dto;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace WebApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;

        public UserController(
            IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("Successfully tested.");
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            _userBusiness.Create(user);

            return StatusCode(Status201Created);
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            _userBusiness.Delete(id);

            return StatusCode(Status204NoContent);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var user = _userBusiness.Get(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userBusiness.GetAll();
            if (users == null || !users.Any())
                return NotFound();
            return Ok(users);
        }

        [HttpPut]
        public IActionResult Update(User user)
        {
            _userBusiness.Update(user);

            return Ok();
        }
    }
}