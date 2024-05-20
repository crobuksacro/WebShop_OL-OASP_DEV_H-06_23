using Shared_OL_OASP_DEV_H_06_23.Models.Binding.OrderModels;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.OrderModels;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.ProductModels;
using System.Security.Claims;
using WebShop_OL_OASP_DEV_H_06_23.Models.Dbo.UserModel;

namespace WebShop_OL_OASP_DEV_H_06_23.Services.Interfaces
{
    public interface IBuyerService
    {
        /// <summary>
        /// Get product items by ids
        /// </summary>
        /// <param name="productItemIds"></param>
        /// <returns></returns>
        Task<List<ProductItemViewModel>> GetProductItems(List<long> productItemIds);
        /// <summary>
        /// Delete order
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<OrderViewModel> DeleteOrder(long id);
        /// <summary>
        /// Get all orders
        /// </summary>
        /// <returns></returns>
        Task<List<OrderViewModel>> GetOrders();

        /// <summary>
        /// Get order by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<OrderViewModel> GetOrder(long id);
        /// <summary>
        /// Order item
        /// </summary>
        /// <param name="model"></param>
        /// <param name="buyer"></param>
        /// <returns></returns>
        Task<OrderViewModel> Order(OrderBinding model, ApplicationUser buyer);

        /// <summary>
        /// Add order by Buyer User
        /// </summary>
        /// <param name="model"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<OrderViewModel> Order(OrderBinding model, ClaimsPrincipal user);
        /// <summary>
        /// Get orders by user role
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        Task<List<OrderViewModel>> GetOrders(ClaimsPrincipal user);
    }
}