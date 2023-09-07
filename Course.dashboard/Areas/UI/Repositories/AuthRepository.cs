using Castle.Components.DictionaryAdapter.Xml;
using Course.Domain.Domains;
using Course.Repository.Context;

namespace Course.dashboard.Areas.UI.Repositories {
	public class AuthRepository : IAuthRepository {
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly CourseDbContext _courseDbContext;

		public AuthRepository(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager, CourseDbContext courseDbContext)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_roleManager = roleManager;
			_courseDbContext = courseDbContext;
		}



		public async Task<bool> RegisterUI(RegisterViewModel model)
		{
			// Fill Data
			var user = new AppUser()
			{
				Name = model.Username,
				UserName = model.EmailAddress,
				Email = model.EmailAddress
			};
			// Save Data
			var result = await _userManager.CreateAsync(user, model.Password);
			if (!result.Succeeded)
			{
				return false;
			}
			var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
			await _userManager.ConfirmEmailAsync(user, token);
			await _signInManager.SignInAsync(user, isPersistent: false);
			// Test Case For Role Is Exist

			if (!await _roleManager.RoleExistsAsync("user"))
			{
				var role = new IdentityRole()
				{
					Name = "user",
					NormalizedName = "USER",
					ConcurrencyStamp = Guid.NewGuid().ToString(),
				};
				var SaveRole = await _roleManager.CreateAsync(role);
				if (!SaveRole.Succeeded)
					return false;
			}
			// Add User In Role.
			if (!await _userManager.IsInRoleAsync(user, "user"))
			{
				var UserInRole = await _userManager.AddToRoleAsync(user, "user");
				if (!UserInRole.Succeeded)
					return false;
			}
			return true;
		}
		public async Task LogOut()
		{
			await _signInManager.SignOutAsync();
		}

		public async Task<string> Login(LoginViewModel model)
		{
			var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RemmberMe, true);
			if (!result.Succeeded)
				return string.Empty;
			var user = await _userManager.FindByEmailAsync(model.Email);
			if (await _userManager.IsInRoleAsync(user, "Admin") || await _userManager.IsInRoleAsync(user, "Professor"))
			{
				return "Home/Index";

			}
			return "user";
		}

		public async Task<bool> Contactus(ContactUsViewModel contact)
		{
			try
			{
				_courseDbContext.Add<ContactUs>(new ContactUs() { Email = contact.Email, Message = contact.Message, Name = contact.Name });
				await _courseDbContext.SaveChangesAsync();
				return true;
			}
			catch (Exception)
			{

				return false;
			}

		}
	}
}
