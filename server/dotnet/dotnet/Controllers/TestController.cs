using Microsoft.AspNetCore.Mvc;

namespace ThanhCometics.API.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
