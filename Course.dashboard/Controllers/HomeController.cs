using Microsoft.AspNetCore.Mvc;

namespace Course.dashboard.Controllers {
    public class HomeController : Controller {
        public IActionResult Index()
        {
            return View();
        }
    }
}
