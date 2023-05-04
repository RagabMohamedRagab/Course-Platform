
using Course.Domain.Domains;
using Course.Repository.IRepositories;
using Course.Repository.ViewModeles;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
                bool IsFind = await _roleManager.RoleExistsAsync("Professor");
                if (IsFind)
                {
                    if (!await _userManager.IsInRoleAsync(user, "Professor"))
                    {
                        await _userManager.AddToRoleAsync(user, "Professor");
                    }
                }
                else
                {
                    IdentityResult role = await _roleManager.CreateAsync(new IdentityRole() { Name = "Professor", NormalizedName = "PROFESSOR", ConcurrencyStamp = Guid.NewGuid().ToString() });
                    if (role.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, "Professor");
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
                await _signInManager.SignOutAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }


        }
        public async Task<IEnumerable<RolesViewModel>> GetAllRole()
        {
            return await _roleManager.Roles.Select(b => new RolesViewModel() { Code = b.Id, Name = b.Name }).ToListAsync();
        }
        public async Task<AddRoleViewModel> AddRole(AddRoleViewModel model)
        {
            IdentityRole role = new IdentityRole()
            {
                Name = model.Name
            };
            IdentityResult result = await _roleManager.CreateAsync(role);
            return result.Succeeded ? new AddRoleViewModel() { Id = role.Id, Name = role.Name } : null;
        }
        public async Task<AddRoleViewModel> DeleteRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role is null)
                return null;
            IdentityResult result = await _roleManager.DeleteAsync(role);
            return result.Succeeded ? new AddRoleViewModel() { Id = role.Id, Name = role.Name } : null;
        }
        public async Task<AddRoleViewModel> GetRoleById(string Id)
        {
            var role = await _roleManager.FindByIdAsync(Id);
            return role is null ? null : new AddRoleViewModel() { Id = role.Id, Name = role.Name };
        }
        public async Task<IList<string>> UserInRole(string roleName)
        {
            IList<string> userInRoles = new List<string>();
            foreach (var item in await _userManager.Users.ToListAsync())
            {
                if (await _userManager.IsInRoleAsync(item, roleName))
                {
                    userInRoles.Add(item.UserName);
                }
            }
            return userInRoles;
        }
        public async Task<bool> UpdateRole(UpdateRoleViewModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.Id);
            if (role == null) return false;
            role.Name = model.Name;
            IdentityResult result = await _roleManager.UpdateAsync(role);
            return result.Succeeded ? true : false;
        }
        public async Task<IList<UsersInfoViewModel>> UsersInRole(string roleName)
        {
            IList<UsersInfoViewModel> usersInfos = new List<UsersInfoViewModel>();//Count =0
            foreach (var user in await _userManager.Users.ToListAsync())
            {
                UsersInfoViewModel usersInfo = new UsersInfoViewModel()
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                };
                if (await _userManager.IsInRoleAsync(user, roleName))
                {
                    usersInfo.IsSelected = true;
                }
                else
                {
                    usersInfo.IsSelected = false;
                }
                usersInfos.Add(usersInfo);
            }
            return usersInfos;
        }
        public async Task<bool> UpdateUsersInRole(UsersInRoleViewModel model)
        {
            // Users --
            // role   - -
            var role = model.role;
            foreach (UsersInfoViewModel boy in model.UsersInfo)
            {
                IdentityResult result = new IdentityResult();
                // GetUserById
                var user = await _userManager.FindByIdAsync(boy.UserId);
                // test User in Role User
                if (!await _userManager.IsInRoleAsync(user, role.Name) && boy.IsSelected)
                {
                    result = await _userManager.AddToRoleAsync(user, role.Name);
                }
                else if (await _userManager.IsInRoleAsync(user, role.Name) && !boy.IsSelected)
                {
                    result = await _userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }
                if (result.Succeeded)
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        public async Task<ProfileUserViewModel> ProfileUser(string email)
        {
            // Get Full User Info 
            var userInfo = await _userManager.FindByEmailAsync(email);
            if (userInfo is null) return null;
            // ViewModel
            ProfileUserViewModel model = new ProfileUserViewModel()
            {
                Name = (userInfo.Name == null) ? userInfo.UserName : userInfo.Name,
                About = userInfo.About,
                img = userInfo.Logo,
                Facebook = userInfo.Facebook,
                Instagram = userInfo.Instagram,
                Twitter = userInfo.Twitter,
                LinkedIn=userInfo.LinkedIn,
            };
            return model;

        }
        public async Task<bool> UpdateUserInfo(string photo, string newUser, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                if (newUser != null)
                    user.Name = newUser;
                if (photo != null)
                    user.Logo = photo;
                IdentityResult result = await _userManager.UpdateAsync(user);
                return result.Succeeded ? true : false;
            }
            return false;
        }
        public async Task<bool> UpdateUserSocial(string Fb, string Twtter, string insgram, string LIn, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                user.Facebook = Fb;
                user.Twitter = Twtter;
                user.Instagram = insgram;
                user.LinkedIn = LIn;
                IdentityResult result = await _userManager.UpdateAsync(user);
                return result.Succeeded ? true : false;
            }
            return false;
        }
        public async Task<bool> UpdateUserAbout(string about, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                user.About = about;
                IdentityResult result = await _userManager.UpdateAsync(user);
                return result.Succeeded ? true : false;
            }
            return false;
        }
      public async Task<IList<ProfessorInfoViewModel>> GetProfessors(int currentPage, int pageSize)
        {
            int start = ((currentPage - 1) * pageSize),
                 end = pageSize * currentPage;
            var professorsInRole =await  _userManager.GetUsersInRoleAsync("Professor");
            IList<ProfessorInfoViewModel> professorInfos=new List<ProfessorInfoViewModel>();
            professorInfos = professorsInRole.Skip(start).Take(end).Select(b => new ProfessorInfoViewModel()
            {
                Name = (b.Name is null) ? b.UserName : b.Name,
                About=b.About,
                Facebook = b.Facebook,
                LinkedIn = b.LinkedIn,
                Instagram = b.Instagram,
                Twitter = b.Twitter,
                img = b.Logo,
            }).ToList();
            return professorInfos;
        }
    }
}







