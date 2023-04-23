using Course.Service.IServices;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Course.dashboard.Controllers.MVC {
    public class ProfileUserController : Controller {
        private readonly IAccountService _service;
        private readonly IToastNotification _toast;

        public ProfileUserController(IAccountService service, IToastNotification toast)
        {
            _service = service;
            _toast = toast;
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
                _toast.AddSuccessToastMessage("Completed Change");
                return RedirectToAction(nameof(Profile), new { email = email });
            }
            _toast.AddErrorToastMessage("Failed Change");
            return RedirectToAction(nameof(Profile), new { email = email });
        }
        [HttpPost]
        public IActionResult UpdateUserSocial(string Facebook, string Twitter,string Instagram,string email)
        {

            if (_service.UpdateUserSocial(Facebook,Twitter,Instagram,email).Result)
            {
                _toast.AddSuccessToastMessage("Completed Change");
                return RedirectToAction(nameof(Profile), new { email = email });
            }
            _toast.AddErrorToastMessage("Failed Change");
            return RedirectToAction(nameof(Profile), new { email = email });
        }
        [HttpPost]
        public IActionResult UpdateUserAbout(string about,string email)
        {
            if (_service.UpdateUserAbout(about,email).Result)
            {
                _toast.AddSuccessToastMessage("Completed Change");
                return RedirectToAction(nameof(Profile), new { email = email });
            }
            _toast.AddErrorToastMessage("Failed Change");
            return RedirectToAction(nameof(Profile), new { email = email });
        }
    }
}
