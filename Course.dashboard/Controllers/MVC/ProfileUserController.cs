using Microsoft.AspNetCore.Mvc;

namespace Course.dashboard.Controllers.MVC {
    public class ProfileUserController : Controller {
        public IActionResult Profile(string email)
        {
            return View();
        }
    }
}
