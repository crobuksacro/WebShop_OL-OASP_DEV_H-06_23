using Microsoft.AspNetCore.Mvc;
using Shared_OL_OASP_DEV_H_06_23.Models.Binding.ProductModels;
using System.Diagnostics;
using WebShop_OL_OASP_DEV_H_06_23.Models;
using WebShop_OL_OASP_DEV_H_06_23.Services.Interfaces;

namespace WebShop_OL_OASP_DEV_H_06_23.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductService _productService;

        public AdminController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var productCategories = await _productService.GetProductCategories();
            return View(productCategories);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCategoryBinding model)
        {
            await _productService.AddProductCategory(model);
            return RedirectToAction("Index");
        }

    }
}
