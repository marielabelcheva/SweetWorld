using Microsoft.AspNetCore.Mvc;
using SweetWorld.Core.Contracts;
using SweetWorld.Core.Models;
using System.Diagnostics;

namespace SweetWorld.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ContactUs()
        {
            return View();
        }

        /*[HttpPost]
        public IActionResult ContactUs(ContactUsViewModel model)
        {
            if (!ModelState.IsValid) { return View(model); }

            this.homeService.ContactUs(model);
            return View();
        }*/

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}