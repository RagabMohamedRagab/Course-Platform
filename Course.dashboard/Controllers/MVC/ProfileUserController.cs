using Course.Service.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Course.dashboard.Controllers.MVC {
    public class ProfileUserController : Controller {
        private readonly IAccountService _service;

        public ProfileUserController(IAccountService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult Profile(string email)
        {
            var result=_service.ProfileUser(email).Result;
            return View(result);
        }
    }
}
