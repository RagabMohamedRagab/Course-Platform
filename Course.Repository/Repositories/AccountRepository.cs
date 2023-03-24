
using Course.Domain.Domains;
using Course.Repository.IRepositories;
using Course.Repository.ViewModeles;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

namespace Course.Repository.Repositories {
    public class AccountRepository : IAccountRepository {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountRepository(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<bool> Add(RegisterViewModel entity)
        {
            AppUser user = new AppUser()
            {
                UserName = entity.EmailAddress,
                Email = entity.EmailAddress,
                PasswordHash = entity.Password,
            };
            IdentityResult result = await _userManager.CreateAsync(user, entity.Password);
            if (result.Succeeded)
            {
                string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                await _userManager.ConfirmEmailAsync(user, token);
                await _signInManager.SignInAsync(user, isPersistent: false);
                // Role 
                bool IsFind = await _roleManager.RoleExistsAsync("User");
                if (IsFind)
                {
                    if(!await _userManager.IsInRoleAsync(user, "User"))
                    {
                       await _userManager.AddToRoleAsync(user, "User");
                    }
                }
                else
                {
                  IdentityResult role=  await _roleManager.CreateAsync(new IdentityRole() { Name = "User", NormalizedName = "USER", ConcurrencyStamp = Guid.NewGuid().ToString() });
                    if (role.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, "User");
                    }
                }
                return true;
            }
            return false;
        }

        public async Task<bool> ForgetPassword(ForgetPasswordViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user is null) return false;
            string Token = await _userManager.GeneratePasswordResetTokenAsync(user);
            IdentityResult result = await _userManager.ResetPasswordAsync(user, Token, model.Password);
            return result.Succeeded;
        }

        public async Task<bool> Login(LoginViewModel model)
        {
            SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RemmberMe, true);
            return result.Succeeded ? true : false;
        }

        public async Task<bool> Logout()
        {
            try
            {
                await  _signInManager.SignOutAsync();
                return true;
            }
            catch (Exception e) {
                return false;
            }
         

        }
    }
}




