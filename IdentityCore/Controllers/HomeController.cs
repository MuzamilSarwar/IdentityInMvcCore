using IdentityCore.EmailServices;
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
        private readonly IEmailSender snder;

        public HomeController(ILogger<HomeController> logger, IGenralPurpose genral
                              , IEmailSender snder)
        {
            _logger = logger;
            this.genral = genral;
            this.snder = snder;
        }

        public async Task<IActionResult> Index()
        {
            //var result = genral.IsAuthenticated();
            //UserEmailOptions options = new UserEmailOptions
            //{
            //    ToEmails = new List<string>() { "test@gmail.com" }
            //};
            //await email.SendTestEmail(options);
            
            var message = new Message(new string[]{"muzamilsarwar415@gmail.com"},"test","testing out tis");
            snder.SendEmail(message);
        
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