using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shared_OL_OASP_DEV_H_06_23.Models.Binding.OrderModels;
using Shared_OL_OASP_DEV_H_06_23.Models.Dto;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.OrderModels;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.ProductModels;
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
        /// Get product items by ids
        /// </summary>
        /// <param name="productItemIds"></param>
        /// <returns></returns>
        public async Task<List<ProductItemViewModel>> GetProductItems(List<long> productItemIds)
        {
            var dbo = await db.ProductItems.Where(y => productItemIds.Contains(y.Id)).ToListAsync();

            return dbo.Select(y => mapper.Map<ProductItemViewModel>(y)).ToList();

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
        /// Get all orders
        /// </summary>
        /// <returns></returns>
        public async Task<List<OrderViewModel>> GetOrders()
        {
            var dbo = await db.Orders
                .Include(y => y.Buyer)
                 .Include(y => y.OrderItems)
                .Include(y => y.OrderAddress)
                .Where(y => y.Valid)
                .ToListAsync();

            return dbo.Select(y => mapper.Map<OrderViewModel>(y)).ToList();
        }
        /// <summary>
        /// Get orders by user role
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<OrderViewModel>> GetOrders(ClaimsPrincipal user)
        {
            var applicationUser = await userManager.GetUserAsync(user);
            var role = await userManager.GetRolesAsync(applicationUser);

            switch (role[0])
            {
                case Roles.Admin:
                    return await GetOrders();
                case Roles.Buyer:
                    return await GetOrders(applicationUser);
                default:
                    throw new NotImplementedException($"{role[0]} isn't implemented in get orders!");

            }
        }

        /// <summary>
        /// Get orders by buyer
        /// </summary>
        /// <param name="buyer"></param>
        /// <returns></returns>
        public async Task<List<OrderViewModel>> GetOrders(ApplicationUser buyer)
        {
            var dbo = await db.Orders
                .Include(y => y.Buyer)
                 .Include(y => y.OrderItems)
                .Include(y => y.OrderAddress)
                .Where(y => y.Valid && y.BuyerId == buyer.Id)
                .ToListAsync();

            return dbo.Select(y => mapper.Map<OrderViewModel>(y)).ToList();
        }

        /// <summary>
        /// Get order by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<OrderViewModel> GetOrder(long id)
        {
            var dbo = await db.Orders
                .Include(y => y.Buyer)
                 .Include(y => y.OrderItems)
                .Include(y => y.OrderAddress)
                .FirstOrDefaultAsync(y => y.Id == id);
            return mapper.Map<OrderViewModel>(dbo);
        }


        /// <summary>
        /// Updates order
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<OrderViewModel> UpdateOrder(OrderUpdateBinding model)
        {
            var dbo = await db.Orders
                .Include(y => y.OrderItems)
                .Include(y => y.OrderAddress)
                .FirstOrDefaultAsync(y => y.Id == model.Id);
            mapper.Map(model, dbo);
            await db.SaveChangesAsync();

            return mapper.Map<OrderViewModel>(dbo);
        }

        public async Task<OrderViewModel> DeleteOrder(long id)
        {
            var dbo = await db.Orders.FindAsync(id);
            dbo.Valid = false;
            await db.SaveChangesAsync();
            return mapper.Map<OrderViewModel>(dbo);
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
            var productItems = db.ProductItems
                .Where(y => model.OrderItems.Select(y => y.ProductItemId).Contains(y.Id)).ToList();


            foreach (var product in dbo.OrderItems)
            {
                var target = productItems.FirstOrDefault(y => product.ProductItemId == y.Id);
                if (target != null)
                {
                    target.Quantity -= product.Quantity;
                    product.Price = target.Price;
                }
            }

        
            dbo.Buyer = buyer;
            dbo.CalcualteTotal();

            db.Orders.Add(dbo);
            await db.SaveChangesAsync();
            return mapper.Map<OrderViewModel>(dbo);
        }
    }
}
