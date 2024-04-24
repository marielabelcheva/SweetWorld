﻿using Microsoft.AspNetCore.Identity;
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
        private readonly IIngredientService ingredientService;
        private readonly ICategoryService categoryService;

        public ProductController (
            IProductService productService, 
            IImageService imageService, 
            IConfectionerService confectionerService,
            IClientService clientService,
            UserManager<User> userManager,
            IIngredientService ingredientService, 
            ICategoryService categoryService)
        {
            this.productService = productService;
            this.imageService = imageService;
            this.confectionerService = confectionerService;
            this.clientService = clientService;
            this.userManager = userManager;
            this.ingredientService = ingredientService;
            this.categoryService = categoryService;
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

            var user = await this.userManager.GetUserAsync(this.User);

            var client = await this.clientService.GetClientByUserIdAsync(user.Id);

            await this.productService.AddProductAsync(viewModel, client.Id);

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
            var user = await this.userManager.GetUserAsync(this.User);

            var client = await this.clientService.GetClientByUserIdAsync(user.Id);

            try 
            {
                //for checking if it works - instead client.Id put Guid.Parse("fa6c6780-40d5-4c7e-9e48-fd82d03190b5")
                await this.productService.LikeProduct(id, client.Id); 
            }
            catch(Exception ex) { TempData["message"] = ex.Message; }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Wishlist()
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var client = await this.clientService.GetClientByUserIdAsync(user.Id);

            try 
            {
                //for checking if it works - instead client.Id put Guid.Parse("fa6c6780-40d5-4c7e-9e48-fd82d03190b5")
                return View(await this.productService.WishList(client.Id)); 
            }
            catch(Exception ex) { TempData["message"] = ex.Message; return RedirectToAction("Index"); }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteFromFavourites(Guid? id)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var client = await this.clientService.GetClientByUserIdAsync(user.Id);

            try 
            {
                //for checking if it works - instead client.Id put Guid.Parse("fa6c6780-40d5-4c7e-9e48-fd82d03190b5")
                await this.productService.DeleteFromWishList(id, client.Id); 
            }
            catch (Exception ex) { TempData["message"] = ex.Message; }

            return RedirectToAction("Wishlist");
        }

        [HttpGet]
        public async Task<IActionResult> UploadImage(Guid? productId)
        {
            ProductImageViewModel viewModel = new ProductImageViewModel()
            {
                ProductId = productId
            };

            return await Task.Run(() => View("UploadImage", viewModel));
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(ProductImageViewModel viewModel)
        {
            IFormFile? image = viewModel.Picture;
            if (image != null && image.Length > 0)
            {
                var imageURL = await this.imageService.UploadImageAsync(image, "products", viewModel.ProductId);
                ViewBag.ImageURL = imageURL;
            }
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> AddIngredient(Guid? productId)
        {
            ProductAddIngredientOrCategoryViewModel viewModel = new ProductAddIngredientOrCategoryViewModel()
            {
                ProductId = productId
            };

            ViewBag.IngredientsId = this.ingredientService.GetIngredientsAsync();

            return await Task.Run(() => View("AddIngredient", viewModel));
        }

        [HttpPost]
        public async Task<IActionResult> AddIngredient(ProductAddIngredientOrCategoryViewModel viewModel)
        {
            try { await this.ingredientService.AddIngredientOfAProductAsync(viewModel.ProductId, viewModel.ItemId); }
            catch (Exception ex) { TempData["message"] = ex.Message; }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid? id)
        {
            try
            {
                var viewModel = await this.productService.EditProductAsync(id);
                return await Task.Run(() => View("Edit", viewModel));
            }
            catch(Exception ex)
            {
                TempData["message"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditProductViewModel viewModel)
        {
            try { await this.productService.EditProductAsync(viewModel); }
            catch (Exception ex) { TempData["message"] = ex.Message; }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> AddCategory(Guid? productId)
        {
            ProductAddIngredientOrCategoryViewModel viewModel = new ProductAddIngredientOrCategoryViewModel()
            {
                ProductId = productId
            };

            ViewBag.CategoriesId = this.categoryService.GetAllCategoriesAsync();

            return await Task.Run(() => View("AddCategory", viewModel));
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(ProductAddIngredientOrCategoryViewModel viewModel)
        {
            try { await this.categoryService.AddCategoryOfaProductAsync(viewModel.ProductId, viewModel.ItemId); }
            catch (Exception ex) { TempData["message"] = ex.Message; }

            return RedirectToAction("Index");
        }
    }
}
