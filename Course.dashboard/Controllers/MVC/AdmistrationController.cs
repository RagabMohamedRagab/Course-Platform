using Microsoft.AspNetCore.Mvc;

namespace Course.dashboard.Controllers.MVC {
    public class AdmistrationController : Controller {
        [HttpGet]
        public IActionResult Roles()
        {
            return View();
        }
    }
}
