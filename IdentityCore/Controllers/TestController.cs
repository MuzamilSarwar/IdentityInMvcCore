using Microsoft.AspNetCore.Mvc;

namespace IdentityCore.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
