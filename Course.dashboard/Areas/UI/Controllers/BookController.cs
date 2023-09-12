using Microsoft.AspNetCore.Mvc;

namespace Course.dashboard.Areas.UI.Controllers {
    [Area("UI")]
    public class BookController : Controller {
        public IActionResult Index()
        {
            return View();
        }
    }
}
