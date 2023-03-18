using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Course.dashboard.Controllers {
    public class HomeController : Controller {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
    }
}
