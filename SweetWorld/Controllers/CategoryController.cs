﻿using Microsoft.AspNetCore.Mvc;
using SweetWorld.Core.Contracts;
using SweetWorld.Core.Models.CategoryViewModels;
using SweetWorld.Core.Models.ProductViewModels;

namespace SweetWorld.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService) { this.categoryService = categoryService; }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                return View(await this.categoryService.AllCategoriesAsync());
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
        public async Task<IActionResult> Add(CategoryViewModel viewModel)
        {
            try { await this.categoryService.AddCategoryAsync(viewModel); }
            catch(Exception ex) { TempData["message"] = ex.Message; }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid? id)
        {
            try { await this.categoryService.DeleteCategoryAsync(id); }
            catch(Exception ex) { TempData["message"] = ex.Message; }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> AddCategoryOfAProduct(Guid? productId)
        {
            ProductAddIngredientOrCategoryViewModel viewModel = new ProductAddIngredientOrCategoryViewModel()
            {
                ProductId = productId
            };

            ViewBag.CategoriesId = this.categoryService.GetAllCategoriesAsync();

            return await Task.Run(() => View("AddCategoryOfAProduct", viewModel));
        }

        [HttpPost]
        public async Task<IActionResult> AddCategoryOfAProduct(ProductAddIngredientOrCategoryViewModel viewModel)
        {
            try { await this.categoryService.AddCategoryOfaProductAsync(viewModel.ProductId, viewModel.ItemId); }
            catch (Exception ex) { TempData["message"] = ex.Message; }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCategoryOfAProduct(Guid? productId)
        {
            //
            try
            {
                return View(await this.categoryService.GetAllCategoriesOfAProductAsync(productId));
            }
            catch (Exception ex) { TempData["message"] = ex.Message; }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategoryOfAProduct(ProductAddIngredientOrCategoryViewModel viewModel)
        {
            try { await this.categoryService.AddCategoryOfaProductAsync(viewModel.ProductId, viewModel.ItemId); }
            catch (Exception ex) { TempData["message"] = ex.Message; }

            return RedirectToAction("Index");
        }
    }
}