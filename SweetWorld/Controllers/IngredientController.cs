using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SweetWorld.Core.Contracts;
using SweetWorld.Core.Models.IngredientViewModels;
using SweetWorld.Core.Models.ProductViewModels;

namespace SweetWorld.Controllers
{
    [Authorize(Roles = "Confectioner")]
    public class IngredientController : Controller
    {
        private readonly IIngredientService ingredientService;

        public IngredientController(IIngredientService ingredientService)
        {
            this.ingredientService = ingredientService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                return View(await this.ingredientService.GetAllIngredientsAsync());
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;
                return View();
            }
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(IngredientViewModel viewModel)
        {
            try { await this.ingredientService.AddIngredientAsync(viewModel); }
            catch (Exception ex) { TempData["message"] = ex.Message; }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid? id)
        {
            try { await this.ingredientService.DeleteIngredientAsync(id); }
            catch (Exception ex) { TempData["message"] = ex.Message; }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> AddIngredientOfAProduct(Guid? productId)
        {
            ProductAddIngredientOrCategoryViewModel viewModel = new ProductAddIngredientOrCategoryViewModel()
            {
                ProductId = productId
            };

            ViewBag.IngredientsId = this.ingredientService.GetIngredientsAsync();

            return await Task.Run(() => View("AddIngredientOfAProduct", viewModel));
        }

        [HttpPost]
        public async Task<IActionResult> AddIngredientOfAProduct(ProductAddIngredientOrCategoryViewModel viewModel)
        {
            try { await this.ingredientService.AddIngredientOfAProductAsync(viewModel.ProductId, viewModel.ItemId); }
            catch (Exception ex) { TempData["message"] = ex.Message; }

            return RedirectToAction("Index");
        }
    }
}
