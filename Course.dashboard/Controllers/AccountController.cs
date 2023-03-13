using Microsoft.AspNetCore.Mvc;

namespace Course.dashboard.Controllers {
    public class AccountController : Controller {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
    }
}
