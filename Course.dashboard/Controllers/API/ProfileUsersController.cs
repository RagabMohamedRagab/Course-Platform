using Course.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Course.dashboard.Controllers.API {
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProfileUsersController : ControllerBase {
        private readonly IAccountService _service;

        public ProfileUsersController(IAccountService accountService)
        {
            _service = accountService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Profile(string email)
        {
            var result = _service.ProfileUser(email);
            if (result == null)
            {
                return NotFound(new { Data = result, Message = "Your Request Falied" });
            }
            return Ok(new { Data = result, Message = "Done" });
        }
        [HttpPost]
        public IActionResult UpdateUserNameAndPhoto(string email, string username, IFormFile userphoto)
        {
            if (_service.UpdateUserInfo(userphoto, username, email).Result)
            {

                return Ok(new { Message = "Done" });
            }

            return NotFound(new { Message = "Your Request Falied" });
        }
        [HttpPost]
        public IActionResult UpdateUserSocial(string Facebook, string Twitter, string Instagram, string linkedin, string email)
        {

            if (_service.UpdateUserSocial(Facebook, Twitter, Instagram,linkedin, email).Result)
            {

                return Ok(new { Message = "Done" });
            }

            return NotFound(new { Message = "Your Request Falied" });
        }
        [HttpPost]
        public IActionResult UpdateUserAbout(string about, string email)
        {
            if (_service.UpdateUserAbout(about, email).Result)
            {
                return Ok(new { Message = "Done" });
            }
            return NotFound(new { Message = "Your Request Falied" });
        }
    }
}





