using AutoMapper;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.ProductModels;
using WebShop_OL_OASP_DEV_H_06_23.Data;

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
        /// Get product Category by id
        /// </summary>
        /// <returns></returns>
        public async Task<ProductCategoryViewModel> GetProductCategorie(long id)
        {
            var dbo = await db.ProductCategorys.FindAsync(id);
            return mapper.Map<ProductCategoryViewModel>(dbo);

        }

    }
}
