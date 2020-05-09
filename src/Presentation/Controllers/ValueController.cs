using Microsoft.AspNetCore.Mvc;

namespace WebApi.Presentation.Controllers
{
    [Route("api/value")]
    [ApiController]
    public class ValueController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(new string[] { "value 1", "value 2" });
        }
    }
}