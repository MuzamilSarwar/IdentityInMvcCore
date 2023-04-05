using IdentityCore.Models;
using IdentityCore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace IdentityCore.Controllers
{
    public class OathController : Controller
    {
        private readonly IOathRepo oathRepo;

        public OathController(IOathRepo oathRepo) 
        {
            this.oathRepo = oathRepo;
        }

        [Route("signup")]
        public IActionResult signUp()
        {
            return View();
        }
        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> signUp(SignUpDto obj)
        {
            if(ModelState.IsValid)
            {
                var result = await oathRepo.CreateUserAsync(obj);
                if (!result.Succeeded) 
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View();
                }
                ModelState.Clear();
                return RedirectToAction("Index","Home");
            }
            else
            {
                ModelState.AddModelError("", "invalid Fields");
                return View();
            }
            
        }
    }
}
