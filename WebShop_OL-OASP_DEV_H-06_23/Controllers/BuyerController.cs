using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared_OL_OASP_DEV_H_06_23.Models.Binding.OrderModels;
using Shared_OL_OASP_DEV_H_06_23.Models.Dto;
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

    }
}
