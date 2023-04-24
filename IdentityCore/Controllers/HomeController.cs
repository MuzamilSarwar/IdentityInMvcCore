using IdentityCore.Helper;
using IdentityCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IdentityCore.Controllers
{
    //This will chek if the user is loged In if yest then proceed otherwise not
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGenralPurpose genral;
        private readonly IEmailService email;

        public HomeController(ILogger<HomeController> logger, IGenralPurpose genral,IEmailService email)
        {
            _logger = logger;
            this.genral = genral;
            this.email = email;
        }

        public async Task<IActionResult> Index()
        {
            var result = genral.IsAuthenticated();
            UserEmailOptions options = new UserEmailOptions
            {
                ToEmails = new List<string>() { "test@gmail.com" }
            };
            await email.SendTestEmail(options);
            
        
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}