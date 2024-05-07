using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SweetWorld.Core.Contracts;
using SweetWorld.Core.Models;
using SweetWorld.Core.Models.HomeViewModels;
using System.Diagnostics;

namespace SweetWorld.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeService homeService;

        public HomeController(ILogger<HomeController> logger, IHomeService homeService)
        {
            _logger = logger;
            this.homeService = homeService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            if (this.User.IsInRole("Confectioner") || this.User.IsInRole("Administrator"))
            {
                return RedirectToAction("MyProducts", "Product");
            }
            else if (this.User.IsInRole("Client")) { return RedirectToAction("AllOrders", "Order"); }

            return View();
        }

        [AllowAnonymous]
        [Authorize(Roles = "Client")]
        public IActionResult AboutUs()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        [Authorize(Roles = "Client")]
        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [Authorize(Roles = "Client")]
        public IActionResult ContactUs(ContactUsViewModel model)
        {
            if (!ModelState.IsValid) { return View(model); }

            this.homeService.ContactUs(model);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}