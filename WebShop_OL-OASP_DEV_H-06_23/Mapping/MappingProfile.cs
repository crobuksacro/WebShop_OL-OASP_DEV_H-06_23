﻿using AutoMapper;
using Shared_OL_OASP_DEV_H_06_23.Models.Binding.Common;
using Shared_OL_OASP_DEV_H_06_23.Models.Binding.CompanyModels;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.Common;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.CompanyModels;
using WebShop_OL_OASP_DEV_H_06_23.Models.Dbo.Common;
using WebShop_OL_OASP_DEV_H_06_23.Models.Dbo.CompanyModels;

namespace WebShop_OL_OASP_DEV_H_06_23.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
        //Ja sam izmjena u kodu
            CreateMap<AddressBinding, Address>();
            CreateMap<AddressUpdateBinding, Address>();
            CreateMap<Address, AddressViewModel>();

            CreateMap<Company, CompanyViewModel>();
            CreateMap<CompanyUpdateBinding, Company>();
            
        }
    }
}
