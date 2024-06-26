using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared_OL_OASP_DEV_H_06_23.Models.Binding.AccountModels;
using Shared_OL_OASP_DEV_H_06_23.Models.Dto;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.UserModel;
using WebShop_OL_OASP_DEV_H_06_23.Services.Interfaces;

namespace WebShop_OL_OASP_DEV_H_06_23.Controllers
{
    public class AccountController : Controller
    {

        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationBinding model)
        {
            await accountService.CreateUser(model, Roles.Buyer);

            return RedirectToAction("Index", "Buyer");
        }

        [Authorize]
        public async Task<IActionResult> MyProfile()
        {
            var profile =await accountService.GetUserProfileAsync<ApplicationUserUpdateBinding>(User);
            return View(profile);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> MyProfile(ApplicationUserUpdateBinding model)
        {
            await accountService.UpdateUserProfileAsync(model);
            return RedirectToAction("MyProfile");
        }

        

    }
}
