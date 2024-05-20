using Shared_OL_OASP_DEV_H_06_23.Models.Binding.AccountModels;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.Common;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.UserModel;
using System.Security.Claims;

namespace WebShop_OL_OASP_DEV_H_06_23.Services.Interfaces
{
    public interface IAccountService
    {
        /// <summary>
        /// Get user user address
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<AddressViewModel> GetUserAddress(ClaimsPrincipal user);
        Task<bool> CreateUser(RegistrationBinding model, string role);
        Task<List<ApplicationUserViewModel>> GetRegUsers(DateTime? notBefore = null);
    }
}