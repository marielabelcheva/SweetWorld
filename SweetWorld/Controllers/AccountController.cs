using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SweetWorld.Data.Models;
using SweetWorld.Models.AccountViewModels;

namespace SweetWorld.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            if (User?.Identity?.IsAuthenticated ?? false) { return RedirectToAction("Index", "Home"); }

            return View(new RegisterViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) { return View(model); }

            User user = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.UserName
            };

            var result = await this.userManager.CreateAsync(user, model.Password);

            if (result.Succeeded) { return RedirectToAction("Login", "Account"); }

            foreach (var error in result.Errors) { ModelState.AddModelError("", error.Description); }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            if (User?.Identity?.IsAuthenticated ?? false) { return RedirectToAction("Index", "Home"); }

            return View(new LoginViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) { return View(model); }

            User user = await this.userManager.FindByNameAsync(model.UserName);

            if (user != null)
            {
                var result = await this.signInManager.PasswordSignInAsync(user, model.Password, false, false);

                if (result.Succeeded) { return RedirectToAction("Index", "Home"); }
            }

            ModelState.AddModelError("", "Invalid login!");
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await this.signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
