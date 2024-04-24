using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.ProductModels;
using WebShop_OL_OASP_DEV_H_06_23.Data;
using WebShop_OL_OASP_DEV_H_06_23.Models.Dbo.ProductModels;

namespace WebShop_OL_OASP_DEV_H_06_23.Services.Implementations
{
    public class ProductService
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;

        public ProductService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        /// <summary>
        /// Get product Categorys
        /// </summary>
        /// <returns></returns>
        public async Task<List<ProductCategoryViewModel>> GetProductCategories()
        {
            var dbos = await db.ProductCategorys.ToListAsync();
            return dbos.Select(y=> mapper.Map<ProductCategoryViewModel>(y)).ToList();

        }

    }
}
