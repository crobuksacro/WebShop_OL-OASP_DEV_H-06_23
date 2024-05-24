using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shared_OL_OASP_DEV_H_06_23.Models.Binding.AccountModels;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.Common;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.UserModel;
using System.Security.Claims;
using WebShop_OL_OASP_DEV_H_06_23.Data;
using WebShop_OL_OASP_DEV_H_06_23.Models.Dbo.UserModel;
using WebShop_OL_OASP_DEV_H_06_23.Services.Interfaces;

namespace WebShop_OL_OASP_DEV_H_06_23.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private UserManager<ApplicationUser> userManager;
        private ApplicationDbContext db;
        private IMapper mapper;
        private SignInManager<ApplicationUser> signInManager;


        public AccountService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext db, IMapper mapper)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.db = db;
            this.mapper = mapper;
        }

        /// <summary>
        /// Get current user profile
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<ApplicationUserViewModel> GetUserProfile(ClaimsPrincipal user)
        {

            var dbo = await db.Users
                .Include(y=>y.Address)
                .FirstOrDefaultAsync(y => y.Id == userManager.GetUserId(user)); 
            return mapper.Map<ApplicationUserViewModel>(dbo);
        }

        /// <summary>
        /// Get user user address
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<AddressViewModel> GetUserAddress(ClaimsPrincipal user)
        {
            var applicationUser = await userManager.GetUserAsync(user);
            var dboUser = await db.Users.Include(y => y.Address)
                .FirstOrDefaultAsync(y => y.Id == applicationUser.Id);
            return mapper.Map<AddressViewModel>(dboUser.Address);
        }

        public async Task<bool> CreateUser(RegistrationBinding model, string role)
        {
            var find = await userManager.FindByEmailAsync(model.Email);
            if (find != null)
            {
                return false;
            }

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                RegistrationDate = DateTime.Now
            };

            user.EmailConfirmed = true;
            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, role);
                await userManager.UpdateAsync(user);
                await signInManager.SignInAsync(user, isPersistent: false);
                return true;
            }

            return false;

        }


        public async Task<List<ApplicationUserViewModel>> GetRegUsers(DateTime? notBefore = null)
        {

            if (!notBefore.HasValue)
            {
                notBefore = DateTime.Now.AddDays(-1);
            }
            var newUsers = await db.Users.Where(y => y.RegistrationDate > notBefore).ToListAsync();
            return newUsers.Select(y => mapper.Map<ApplicationUserViewModel>(y)).ToList();

        }

    }
}
