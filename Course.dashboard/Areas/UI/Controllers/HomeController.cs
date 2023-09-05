using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Course.dashboard.Areas.UI.Controllers {
    [Area("UI")]
    public class HomeController : Controller {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
    }
}
