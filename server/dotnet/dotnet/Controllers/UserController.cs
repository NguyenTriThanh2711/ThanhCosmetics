using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ThanhCometics.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok("Hello from UserController!");
        }
    }
}
