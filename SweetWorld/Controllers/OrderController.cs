using CloudinaryDotNet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SweetWorld.Core.Contracts;
using SweetWorld.Core.Models.OrderViewModels;
using SweetWorld.Core.Models.Pagination;
using SweetWorld.Core.Models.ProductViewModels;
using SweetWorld.Infrastructure.Data.Models;

namespace SweetWorld.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private IOrderService orderService;
        private IConfectionerService confectionerService;
        private IClientService clientService;
        private readonly UserManager<User> userManager;

        public OrderController(IOrderService orderService, 
            IConfectionerService confectionerService, 
            IClientService clientService, 
            UserManager<User> userManager)
        {
            this.orderService = orderService;
            this.confectionerService = confectionerService;
            this.clientService = clientService;
            this.userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AllOrders(int page = 1)
        {
            try
            {
                IEnumerable<OrderClientViewModel>? items = null!;
                var pager = new Pager();

                if (this.User.IsInRole("Administrator")) 
                { 
                    items = await this.orderService.GetAllUnaprovedOrdersAsync(page);
                    pager = this.orderService.Pager;
                }
                else if (this.User.IsInRole("Confectioner")) 
                {
                    var user = await this.userManager.GetUserAsync(this.User);

                    var confectioner = await this.confectionerService.GetConfectionerByUserIdAsync(user.Id);

                    items = await this.confectionerService.AllOrdersForExecutingAsync(page, confectioner);
                    pager = this.confectionerService.Pager;
                }
                else
                {
                    var user = await this.userManager.GetUserAsync(this.User);

                    var client = await this.clientService.GetClientByUserIdAsync(user.Id);

                    items = await this.clientService.AllOrdersOfAClientAsync(page, client?.Id);
                    pager = this.clientService.Pager;
                }

                pager.Controller = "Order";
                pager.Action = "AllOrders";
                ViewBag.Pager = pager;

                return View(items);
            }
            catch (Exception ex) 
            { 
                TempData["message"] = ex.Message; 
                return RedirectToAction("Index", "Home"); 
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> OrderDetail(Guid id) { return View(await this.orderService.OrderDetailAsync(id)); }

        [HttpGet]
        [Authorize(Roles = "Client,Administrator")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            try
            {
                await this.orderService.DeleteOrderAsync(id);
            }
            catch (Exception ex) { TempData["message"] = ex.Message; }

            return RedirectToAction("AllOrders");
        }

        [HttpGet]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> CartOrders()
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var client = await this.clientService.GetClientByUserIdAsync(user.Id);

            return View(await this.orderService.AllOrdersFromTheCartAsync(client));
        }

        [HttpGet]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> UpdateCart(Guid? cartId)
        {
            try
            {
                var viewModel = await this.orderService.UpdateCartOrderAsync(cartId);
                return await Task.Run(() => View("UpdateCart", viewModel));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;
                return RedirectToAction("CartOrders");
            }
        }

        [HttpPost]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> UpdateCart(CartOrderViewModel viewModel)
        {
            try { await this.orderService.UpdateCartOrderAsync(viewModel); }
            catch (Exception ex) { TempData["message"] = ex.Message; }

            return RedirectToAction("CartOrders");
        }

        [HttpGet]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> ClearCart()
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var client = await this.clientService.GetClientByUserIdAsync(user.Id);

            await this.orderService.ClearCart(client);

            return RedirectToAction("CartOrders");
        }

        [HttpGet]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> DeleteFromCart(Guid id)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var client = await this.clientService.GetClientByUserIdAsync(user.Id);

            await this.orderService.DeleteOrderFromTheCartAsync(id, client);

            return RedirectToAction("CartOrders");
        }

        [HttpGet]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> AddToCart(Guid? productId)
        {
            try
            {
                var viewModel = await this.orderService.AddOrderToTheCartAsync(productId);
                return await Task.Run(() => View("AddToCart", viewModel));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;
                return RedirectToAction("Index", "Product");
            }
        }

        [HttpPost]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> AddToCart(CartOrderViewModel viewModel)
        {
            try
            {
                var user = await this.userManager.GetUserAsync(this.User);

                var client = await this.clientService.GetClientByUserIdAsync(user.Id);

                await this.orderService.AddOrderToTheCartAsync(viewModel, client);
            }
            catch(Exception ex) { TempData["message"] = ex.Message; }

            return RedirectToAction("CartOrders");
        }

        [HttpGet]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> CheckoutCart() 
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var client = await this.clientService.GetClientByUserIdAsync(user.Id);

            var orders = await this.orderService.AllOrdersFromTheCartAsync(client);
            var sum = orders.ToList().Sum(order => order.UnitPrice * order.Amount);

            ViewBag.Price = sum;
            ViewBag.Total = sum + 7.99m;

            return View(); 
        }

        [HttpPost]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> CheckoutCart(DeliveryViewModel viewModel)
        {
            if (!ModelState.IsValid) { return View(viewModel); }

            var user = await this.userManager.GetUserAsync(this.User);

            var client = await this.clientService.GetClientByUserIdAsync(user.Id);

            await this.orderService.CheckoutCartAsync(viewModel, client);

            return RedirectToAction("AllOrders");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateStatus(Guid? id, string status)
        {
            try { await this.orderService.UpdateStatusOfAnOrderAsync(id, status); }
            catch(Exception ex) { TempData["message"] = ex.Message; }

            return RedirectToAction("Index", "Home");
        }
    }
}
