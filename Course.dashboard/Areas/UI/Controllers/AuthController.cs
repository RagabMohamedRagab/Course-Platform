
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Course.dashboard.Areas.UI.Controllers {
	[Area("UI")]
	public class AuthController : Controller {
		private readonly IAuthRepository _authRepository;
        private readonly IToastNotification _toast;
        public AuthController(IAuthRepository authRepository, IToastNotification toast)
        {
            _authRepository = authRepository;
            _toast = toast;
        }

        [HttpGet]
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(RegisterViewModel model)
		{
			if (!ModelState.IsValid ||await _authRepository.RegisterUI(model))
			{
				ModelState.AddModelError(string.Empty, "incorrect Password or email");
				_toast.AddErrorToastMessage("incorrect Password or email");
				return View();
			}
			return RedirectToAction(nameof(Index), "Home");
		}
        [HttpGet]
		public IActionResult Login()
		{
			return View();
		}
		[HttpGet]
		public IActionResult ContactUs()
		{
			return View();
		}
	}
}
