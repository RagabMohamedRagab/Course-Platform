using Microsoft.AspNetCore.Mvc;

namespace Course.dashboard.Controllers {
    public class AccountController : Controller {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
    }
}
