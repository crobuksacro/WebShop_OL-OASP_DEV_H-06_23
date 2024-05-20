using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shared_OL_OASP_DEV_H_06_23.Models.Binding.OrderModels;
using Shared_OL_OASP_DEV_H_06_23.Models.Dto;
using WebShop_OL_OASP_DEV_H_06_23.Models.Dbo.OrderModels;
using WebShop_OL_OASP_DEV_H_06_23.Services.Interfaces;

namespace WebShop_OL_OASP_DEV_H_06_23.Controllers
{
    [Authorize(Roles = Roles.Buyer)]
    public class BuyerController : Controller
    {

        private readonly IProductService _productService;
        private readonly IBuyerService _buyerService;
        public BuyerController(IProductService productService, IBuyerService buyerService)
        {

            _productService = productService;
            _buyerService = buyerService;
        }

        [HttpPost]
        public async Task<IActionResult> Order(OrderBinding model)
        {
            await _buyerService.Order(model, User);

            return View();
        }


        public async Task<IActionResult> Index()
        {
            var model = await _productService.GetProductCategories();
            return View(model);
        }

        public async Task<IActionResult> Details(long id)
        {
            var productCategory = await _productService.GetProductCategory(id);
            return View(productCategory);
        }


        [HttpPost]
        public async Task<IActionResult> AddToOrderItem([FromBody] List<OrderItemBiding> orderItems)
        {
            // Retrieve the existing session list of OrderItemBiding
            var sessionOrderItems = HttpContext.Session.GetString("OrderItems");
            List<OrderItemBiding> existingOrderItems = sessionOrderItems != null
                ? JsonConvert.DeserializeObject<List<OrderItemBiding>>(sessionOrderItems)
                : new List<OrderItemBiding>();

            // Update the session list with the new order items
            foreach (var orderItem in orderItems)
            {
                var existingItem = existingOrderItems.Find(item => item.ProductItemId == orderItem.ProductItemId);
                if (existingItem != null)
                {
                    // Update the quantity of the existing item
                    existingItem.Quantity += orderItem.Quantity;
                }
                else
                {
                    // Add the new item to the list
                    existingOrderItems.Add(orderItem);
                }
            }

            // Save the updated list back to the session
            HttpContext.Session.SetString("OrderItems", JsonConvert.SerializeObject(existingOrderItems));

            return Json(new { msg = "Ok" });
        }


    }
}
