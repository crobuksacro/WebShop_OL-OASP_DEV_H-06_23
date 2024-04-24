using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WebShop_OL_OASP_DEV_H_06_23.Data;
using WebShop_OL_OASP_DEV_H_06_23.Mapping;
using WebShop_OL_OASP_DEV_H_06_23.Models.Dbo.Common;
using WebShop_OL_OASP_DEV_H_06_23.Services.Implementations;
using WebShop_OL_OASP_DEV_H_06_23.Services.Interfaces;

namespace WebShop_OL_OASP_DEV_H_06_23.UnitTest
{
    public abstract class WebShopSetup
    {
        protected IMapper Mapper { get; private set; }
        protected ApplicationDbContext InMemoryDbContext;
        protected readonly Address Address;


        public WebShopSetup()
        {
            SetupInMemoryContext();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            Mapper = mappingConfig.CreateMapper();
            Address = GenerateAddress();

        }

        private Address GenerateAddress()
        {
            Address dbo = new Address
            {
                City = "Zagreb",
                Created = DateTime.Now,
                Country = "Hrvatska",
                Street = "Maksimirska",
                Number = "100",
                Valid = true
            };

            InMemoryDbContext.Addresss.Add(dbo);
            InMemoryDbContext.SaveChanges();

            return dbo;

        }


        protected ICommonService GetCommonService(ApplicationDbContext? db = null)
        {
            if (db != null)
            {
                return new CommonService(db, Mapper);
            }
            return new CommonService(InMemoryDbContext, Mapper);

        }
        protected IAdminService GetAdminService(ApplicationDbContext? db = null)
        {
            if (db != null)
            {
                return new AdminService(db, Mapper);
            }
            return new AdminService(InMemoryDbContext, Mapper);

        }

        private void SetupInMemoryContext()
        {
            var inMemoryOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                            .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                            .Options;
            InMemoryDbContext = new ApplicationDbContext(inMemoryOptions);
        }
    }
}
