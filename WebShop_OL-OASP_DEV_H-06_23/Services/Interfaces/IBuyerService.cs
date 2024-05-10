using Shared_OL_OASP_DEV_H_06_23.Models.Binding.OrderModels;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.OrderModels;
using System.Security.Claims;
using WebShop_OL_OASP_DEV_H_06_23.Models.Dbo.UserModel;

namespace WebShop_OL_OASP_DEV_H_06_23.Services.Interfaces
{
    public interface IBuyerService
    {

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
    }
}