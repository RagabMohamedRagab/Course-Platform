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
        [HttpPost]
        public IActionResult UpdateUserNameAndPhoto(string email,string username,IFormFile userphoto)
        {
           if( _service.UpdateUserInfo(userphoto,username, email).Result)
            {
                return RedirectToAction(nameof(Profile), new { email = email });
            }
            return View();
        }
        [HttpPost]
        public IActionResult UpdateUserSocial(string Facebook, string Twitter,string Instagram)
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateUserAbout(string about)
        {
            return View();
        }
    }
}
