using AutoMapper;
using Shared_OL_OASP_DEV_H_06_23.Models.Binding.Common;
using Shared_OL_OASP_DEV_H_06_23.Models.Binding.CompanyModels;
using Shared_OL_OASP_DEV_H_06_23.Models.Binding.OrderModels;
using Shared_OL_OASP_DEV_H_06_23.Models.Binding.ProductModels;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.Common;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.CompanyModels;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.OrderModels;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.ProductModels;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.UserModel;
using WebShop_OL_OASP_DEV_H_06_23.Models.Dbo.Common;
using WebShop_OL_OASP_DEV_H_06_23.Models.Dbo.CompanyModels;
using WebShop_OL_OASP_DEV_H_06_23.Models.Dbo.OrderModels;
using WebShop_OL_OASP_DEV_H_06_23.Models.Dbo.ProductModels;
using WebShop_OL_OASP_DEV_H_06_23.Models.Dbo.UserModel;

namespace WebShop_OL_OASP_DEV_H_06_23.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<QuantityType, QuantityTypeViewModel>();
            CreateMap<OrderUpdateBinding, Order>();
            CreateMap<OrderBinding, Order>();
            CreateMap<Order, OrderViewModel>();
            CreateMap<OrderItemBiding, OrderItem>();
            CreateMap<OrderItemUpdateBiding, OrderItem>();
            CreateMap<OrderItem, OrderItemViewModel>();

            CreateMap<ApplicationUserUpdateBinding, ApplicationUser>();
            CreateMap<Address, AddressUpdateBinding>();
            CreateMap<ApplicationUser, ApplicationUserUpdateBinding>();


            CreateMap<ApplicationUser, ApplicationUserViewModel>();
            CreateMap<ProductItemViewModel, ProductItemUpdateBinding>();
            CreateMap<AddressBinding, Address>();
            CreateMap<AddressUpdateBinding, Address>();
            CreateMap<Address, AddressViewModel>();
            CreateMap<Company, CompanyViewModel>();
            CreateMap<CompanyUpdateBinding, Company>();

            CreateMap<ProductCategoryViewModel, ProductCategoryUpdateBinding>();
            CreateMap<ProductCategory, ProductCategoryViewModel>();
            CreateMap<ProductCategoryBinding, ProductCategory>();
            CreateMap<ProductCategoryUpdateBinding, ProductCategory>();
            CreateMap<ProductItem, ProductItemViewModel>();
            CreateMap<ProductItemBinding, ProductItem>();
            CreateMap<ProductItemUpdateBinding, ProductItem>();
        }
    }
}
