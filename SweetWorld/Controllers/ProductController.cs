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

        public ProductController (
            IProductService productService, 
            IImageService imageService, 
            IConfectionerService confectionerService)
        {
            this.productService = productService;
            this.imageService = imageService;
            this.confectionerService = confectionerService;
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
                return View(await this.productService.ProductDataAsync(id));
            }
            catch(Exception ex) { TempData["message"] = ex.Message; return RedirectToAction("Index"); }
        }
    }
}
