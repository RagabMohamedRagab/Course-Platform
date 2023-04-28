using Microsoft.AspNetCore.Mvc;

namespace Course.dashboard.Controllers.MVC {
    public class ProfessorController : Controller {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
