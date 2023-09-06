
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Course.dashboard.Areas.UI.Controllers {
	[Area("UI")]
	public class AuthController : Controller {
		private readonly IAuthRepository _authRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IToastNotification _toast;
        public AuthController(IAuthRepository authRepository, IToastNotification toast, IHttpContextAccessor httpContextAccessor)
        {
            _authRepository = authRepository;
            _toast = toast;
            _httpContextAccessor = httpContextAccessor;
        }

		[AllowAnonymous]
        [HttpGet]
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
		{
			if (!ModelState.IsValid ||!await _authRepository.RegisterUI(model))
			{
				ModelState.AddModelError(string.Empty, "incorrect Password or email");
				_toast.AddErrorToastMessage("incorrect Password or email");
				return View();
			}
			_httpContextAccessor.HttpContext?.Response.Cookies.Append("UName", model.Username);
            return RedirectToAction(nameof(Index), "Home");
		}
     
         [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			if (!ModelState.IsValid)
			{
				ModelState.AddModelError(string.Empty, "incorrect Password or email");
				_toast.AddErrorToastMessage("incorrect Password or email");
				return View();

			}
			var path = await _authRepository.Login(model);
			if (path == "user")
				return RedirectToAction(nameof(Index), "Home");
			return Redirect("~/"+path);
		}
		[HttpGet]
        public IActionResult ContactUs()
		{
			return View();
		}
		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> LogOut()
		{
			await _authRepository.LogOut();
			_httpContextAccessor.HttpContext?.Response.Cookies.Delete("UName");
			return RedirectToAction(nameof(Register));
		}
	}
}
