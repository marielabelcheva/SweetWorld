using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SweetWorld.Core.Contracts;
using SweetWorld.Core.Models.OrderViewModels;
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
        public async Task<IActionResult> AllOrders()
        {
            try
            {
                if (this.User.IsInRole("Administrator")) { return View(await this.orderService.GetAllUnaprovedOrdersAsync()); }
                else if (this.User.IsInRole("Confectioner")) 
                {
                    var user = await this.userManager.GetUserAsync(this.User);

                    var confectioner = await this.confectionerService.GetConfectionerByUserIdAsync(user.Id);

                    return View(await this.confectionerService.AllOrdersForExecutingAsync(confectioner)); 
                }
                else
                {
                    var user = await this.userManager.GetUserAsync(this.User);

                    var client = await this.clientService.GetClientByUserIdAsync(user.Id);

                    return View(await this.clientService.AllOrdersOfAClientAsync(client?.Id));
                }
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

            return View(this.orderService.AllOrdersFromTheCartAsync(client));
        }

        [HttpGet]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> UpdateCart(IEnumerable<CartOrder> cart)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var client = await this.clientService.GetClientByUserIdAsync(user.Id);

            await this.orderService.UpdateCartAsyncAsync(cart, client);

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
            var order = client?.Cart.FirstOrDefault(c => c.Id == id);

            await this.orderService.DeleteOrderFromTheCartAsync(order, client);

            return RedirectToAction("CartOrders");
        }

        [HttpGet]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> AddToCart(ProductDataViewModel viewModel)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var client = await this.clientService.GetClientByUserIdAsync(user.Id);

            await this.orderService.AddOrderToTheCartAsync(viewModel, client);

            return RedirectToAction("ProductData", "Product", viewModel.Id);
        }

        [HttpGet]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> CheckoutCart() 
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var client = await this.clientService.GetClientByUserIdAsync(user.Id);

            var sum = this.orderService.AllOrdersFromTheCartAsync(client).Sum(order => order.UnitPrice * order.Amount);

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
    }
}
