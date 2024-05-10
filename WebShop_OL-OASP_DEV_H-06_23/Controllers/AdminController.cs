using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared_OL_OASP_DEV_H_06_23.Models.Binding.ProductModels;
using Shared_OL_OASP_DEV_H_06_23.Models.Dto;
using WebShop_OL_OASP_DEV_H_06_23.Services.Interfaces;

namespace WebShop_OL_OASP_DEV_H_06_23.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public class AdminController : Controller
    {
        private readonly IProductService _productService;
        private readonly IAdminService _adminService;
        private readonly IMapper _mapper;

        public AdminController(IProductService productService, IMapper mapper, IAdminService adminService)
        {
            _productService = productService;
            _mapper = mapper;
            _adminService = adminService;
        }

        public async Task<IActionResult> Company()
        {
            var company = await _adminService.GetCompany();
            return View(company);
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


        public async Task<IActionResult> Details(long id)
        {
            var productCategory = await _productService.GetProductCategory(id);
            return View(productCategory);
        }

        public async Task<IActionResult> DetailsProductItem(long id)
        {
            var productCategory = await _productService.GetProductItem(id);
            return View(productCategory);
        }

        


        public async Task<IActionResult> AddProductCategory(long categoryId)
        {
            var model = new ProductItemBinding
            {
                ProductCategoryId = categoryId
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddProductCategory(ProductItemBinding model)
        {

            await _productService.AddProductItem(model);

            return RedirectToAction("Details", new { id = model.ProductCategoryId });
        }


        public async Task<IActionResult> EditProductItem(long id)
        {
            var model = await _productService.GetProductItem(id);
            var response = _mapper.Map<ProductItemUpdateBinding>(model);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> EditProductItem(ProductItemUpdateBinding model)
        {
            var response = await _productService.UpdateProductItem(model);
            return RedirectToAction("Details", new { id = response.ProductCategoryId });
        }

        public async Task<IActionResult> Edit(long id)
        {
            var model = await _productService.GetProductCategory(id);
            var response = _mapper.Map<ProductCategoryUpdateBinding>(model);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductCategoryUpdateBinding model)
        {

            await _productService.UpdateProductCategory(model);

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(long id)
        {
            await _productService.DeleteProductCategory(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteProductItem(long id)
        {
            var response = await _productService.DeleteProductItem(id);
            return RedirectToAction("Details", new { id = response.ProductCategoryId });
        }
    }
}
