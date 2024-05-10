using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shared_OL_OASP_DEV_H_06_23.Models.Binding.OrderModels;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.OrderModels;
using System.Security.Claims;
using WebShop_OL_OASP_DEV_H_06_23.Data;
using WebShop_OL_OASP_DEV_H_06_23.Models.Dbo.OrderModels;
using WebShop_OL_OASP_DEV_H_06_23.Models.Dbo.UserModel;
using WebShop_OL_OASP_DEV_H_06_23.Services.Interfaces;

namespace WebShop_OL_OASP_DEV_H_06_23.Services.Implementations
{
    public class BuyerService : IBuyerService
    {
        private UserManager<ApplicationUser> userManager;
        private ApplicationDbContext db;
        private IMapper mapper;

        public BuyerService(UserManager<ApplicationUser> userManager, ApplicationDbContext db, IMapper mapper)
        {
            this.userManager = userManager;
            this.db = db;
            this.mapper = mapper;
        }

        /// <summary>
        /// Add order by Buyer User
        /// </summary>
        /// <param name="model"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<OrderViewModel> Order(OrderBinding model, ClaimsPrincipal user)
        {
            var applicationUser = await userManager.GetUserAsync(user);
            return await Order(model, applicationUser);

        }

        /// <summary>
        /// Order item
        /// </summary>
        /// <param name="model"></param>
        /// <param name="buyer"></param>
        /// <returns></returns>
        public async Task<OrderViewModel> Order(OrderBinding model, ApplicationUser buyer)
        {
            var dbo = mapper.Map<Order>(model);
            dbo.Buyer = buyer;
            dbo.OrderItems = await db.OrderItems.Where(y => model.OrderItemIds.Contains(y.Id)).ToListAsync();
            db.Orders.Add(dbo);
            await db.SaveChangesAsync();
            return mapper.Map<OrderViewModel>(dbo);
        }
    }
}
