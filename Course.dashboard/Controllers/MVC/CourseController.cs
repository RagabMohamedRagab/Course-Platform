using Microsoft.AspNetCore.Mvc;

namespace Course.dashboard.Controllers.MVC {
    public class CourseController : Controller {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
