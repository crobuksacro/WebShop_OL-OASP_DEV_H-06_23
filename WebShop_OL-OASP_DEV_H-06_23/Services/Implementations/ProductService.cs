using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Shared_OL_OASP_DEV_H_06_23.Models.Dto;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.ProductModels;
using WebShop_OL_OASP_DEV_H_06_23.Data;
using WebShop_OL_OASP_DEV_H_06_23.Models.Dbo.ProductModels;

namespace WebShop_OL_OASP_DEV_H_06_23.Services.Implementations
{
    public class ProductService
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;
        private AppSettings appSettings;


        public ProductService(ApplicationDbContext db, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            this.db = db;
            this.mapper = mapper;
            this.appSettings = appSettings.Value;
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

        public async Task<ProductCategoryPaginationViewModel> GetProductCategories(int page, string? searchTerm = null, int? offset = null)
        {

            if(!offset.HasValue)
            {
                offset = appSettings.PaginationOffset;
            }

            var baseQuery = db.Set<ProductCategory>().Where(y => y.Valid);

            if(!string.IsNullOrWhiteSpace(searchTerm))
            {
                baseQuery = baseQuery.Where(s=> EF.Functions.Like(s.Name,$"%{searchTerm}%") || EF.Functions.Like(s.Description, $"%{searchTerm}%"));
            }
            
            var totalRecords = await baseQuery.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalRecords / offset.Value);

            var basePQuery = await baseQuery
                .Skip((page - 1) * offset.Value)
                .Take(offset.Value)
                .ToListAsync();


            var productCategory = basePQuery.OrderByDescending(y => y.Created).ToList();


            var response = new ProductCategoryPaginationViewModel
            {
                ProductCategorys = basePQuery.Select(y=> mapper.Map<ProductCategoryViewModel>(y)).ToList(),
                Rows= totalPages,
                TotalRecords = totalRecords,
            };

            return response;
        }


        //Ostatak CRUD operacija nad kategorijama
        //Unit testovi
    }
}
