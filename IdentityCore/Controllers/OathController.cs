using IdentityCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace IdentityCore.Controllers
{
    public class OathController : Controller
    {
        [Route("signup")]
        public IActionResult signUp()
        {
            return View();
        }
        [Route("signup")]
        [HttpPost]
        public IActionResult signUp(SignUpDto obj)
        {
            if(ModelState.IsValid)
            {
                ModelState.Clear();
                return View();
            }
            else
            {
                ModelState.AddModelError("", "invalid Fields");

            }
            return View();
        }
    }
}
