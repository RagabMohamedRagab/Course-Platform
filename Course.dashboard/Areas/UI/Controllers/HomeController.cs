using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Course.dashboard.Areas.UI.Controllers {
    [Area("UI")]
    public class HomeController : Controller {
        private readonly IAuthRepository _authRepository;

        public HomeController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _authRepository.IndexRepo());
        }
    }
}
