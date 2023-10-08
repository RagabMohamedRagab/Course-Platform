using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Course.dashboard.Areas.UI.Controllers {
    [Area("UI")]
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller {
        private readonly IAuthRepository _authRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IToastNotification _toast;
        public HomeController(IAuthRepository authRepository, IToastNotification toast, IHttpContextAccessor httpContextAccessor)
        {
            _authRepository = authRepository;
            _toast = toast;
            _httpContextAccessor = httpContextAccessor;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _authRepository.IndexRepo());
        }
        [HttpGet]
        public async Task<IActionResult> AboutUs()
        {
            return View(await _authRepository.AboutUsRepo());
        }
    }
}
