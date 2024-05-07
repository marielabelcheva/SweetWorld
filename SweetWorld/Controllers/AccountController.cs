using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SweetWorld.Infrastructure.Data.Models;
using SweetWorld.Core.Models.AccountViewModels;
using SweetWorld.Core.Contracts;
using SweetWorld.Core.Models.Pagination;

namespace SweetWorld.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IConfectionerService confectionerService;
        private readonly IClientService clientService;
        private readonly IUserService userService;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, 
                                 IClientService clientService, IConfectionerService confectionerService, IUserService userService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.confectionerService = confectionerService;
            this.clientService = clientService;
            this.userService = userService;
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
                UserName = model.UserName,
                PhoneNumber = model.PhoneNumber
            };

            var result = await this.userManager.CreateAsync(user, model.Password);

            if (model.IsConfectioner?.ToLower() == "true")
            {
                await this.confectionerService.AddConfectionerAsync(user.Id);
                await userManager.AddToRoleAsync(user, "Confectioner");
            }
            else
            {
                await this.clientService.AddClientAsync(user.Id);
                await userManager.AddToRoleAsync(user, "Client");
            }

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

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Index(int page = 1)
        {
            var result = await this.clientService.GetAllClientsAsync();
            result = result.Union(await this.confectionerService.GetAllConfectionersAsync());


            if (page < 1) { page = 1; }

            int totalItems =  result.Count();
            var pager = new Pager(totalItems, page);
            pager.Controller = "Account";
            pager.Action = "Index";
            int skipUsers = (page - 1) * pager.PageSize;

            ViewBag.Pager = pager;

            return View(result.Skip(skipUsers).Take(pager.PageSize));
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(string id)
        {
            await this.userService.DeleteUserAsync(id);

            return RedirectToAction("Index");
        }
    }
}
