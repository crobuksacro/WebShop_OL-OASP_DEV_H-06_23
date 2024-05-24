using Shared_OL_OASP_DEV_H_06_23.Models.Binding.AccountModels;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.Common;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.UserModel;
using System.Security.Claims;

namespace WebShop_OL_OASP_DEV_H_06_23.Services.Interfaces
{
    public interface IAccountService
    {

        /// <summary>
        /// Updates user profile
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
         Task<ApplicationUserViewModel> UpdateUserProfileAsync(ApplicationUserUpdateBinding model);
        /// <summary>
        /// Get User Profile Async with dif. response view model
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="user"></param>
        /// <returns></returns>
         Task<T> GetUserProfileAsync<T>(ClaimsPrincipal user);
        /// <summary>
        /// Get user user address
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<AddressViewModel> GetUserAddress(ClaimsPrincipal user);
        Task<bool> CreateUser(RegistrationBinding model, string role);
        Task<List<ApplicationUserViewModel>> GetRegUsers(DateTime? notBefore = null);
        /// <summary>
        /// Get current user profile
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
       Task<ApplicationUserViewModel> GetUserProfileAsync(ClaimsPrincipal user);
    }
}