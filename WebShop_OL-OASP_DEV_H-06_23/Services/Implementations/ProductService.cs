using AutoMapper;
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


    }
}
