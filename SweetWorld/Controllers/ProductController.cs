using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SweetWorld.Core.Contracts;
using SweetWorld.Core.Models.ProductViewModels;
using SweetWorld.Infrastructure.Data.Models;

namespace SweetWorld.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly IImageService imageService;
        private readonly IConfectionerService confectionerService;
        private readonly IClientService clientService;
        private readonly UserManager<User> userManager;

        public ProductController (
            IProductService productService, 
            IImageService imageService, 
            IConfectionerService confectionerService,
            IClientService clientService,
            UserManager<User> userManager)
        {
            this.productService = productService;
            this.imageService = imageService;
            this.confectionerService = confectionerService;
            this.clientService = clientService;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await this.productService.AllProductsAsync());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductViewModel viewModel)
        {
            if (!ModelState.IsValid) { return View(viewModel); }

            await this.productService.AddProductAsync(viewModel, Guid.Parse("e2b8a345-064a-4381-ab50-70724003fcbd"));

            return RedirectToAction("ProductData");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid? id)
        {
            try
            {
                await this.productService.DeleteProductAsync(id);
            }
            catch (Exception ex) { TempData["message"] = ex.Message; }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> ProductData(Guid? id)
        {
            try
            {
                //ViewBag.Pieces = await this.productService.GetPiecesCountOfAProductAsync(id);
                return View(await this.productService.ProductDataAsync(id));
            }
            catch(Exception ex) { TempData["message"] = ex.Message; return RedirectToAction("Index"); }
        }

        [HttpGet]
        public async Task<IActionResult> FavouriteProduct(Guid? id)
        {
            //var user = await this.userManager.GetUserAsync(this.User);

            //var client = await this.clientService.GetClientByUserIdAsync(user.Id);

            try { await this.productService.LikeProduct(id, Guid.Parse("fa6c6780-40d5-4c7e-9e48-fd82d03190b5")); }
            catch(Exception ex) { TempData["message"] = ex.Message; }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Wishlist()
        {
            //var user = await this.userManager.GetUserAsync(this.User);

            //var client = await this.clientService.GetClientByUserIdAsync(user.Id);

            try { return View(await this.productService.WishList(Guid.Parse("fa6c6780-40d5-4c7e-9e48-fd82d03190b5"))); }
            catch(Exception ex) { TempData["message"] = ex.Message; return RedirectToAction("Index"); }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteFromFavourites(Guid? id)
        {
            //var user = await this.userManager.GetUserAsync(this.User);

            //var client = await this.clientService.GetClientByUserIdAsync(user.Id);

            try { await this.productService.DeleteFromWishList(id, Guid.Parse("fa6c6780-40d5-4c7e-9e48-fd82d03190b5")); }
            catch (Exception ex) { TempData["message"] = ex.Message; }

            return RedirectToAction("Wishlist");
        }
    }
}
