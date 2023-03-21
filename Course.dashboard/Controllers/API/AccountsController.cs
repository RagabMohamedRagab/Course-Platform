using Course.Repository.ViewModeles;
using Course.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Course.dashboard.Controllers.API {
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountsController : ControllerBase {
        private readonly IAccountService _accountService;
        private readonly IEmailSender _emailSender;
        public AccountsController(IAccountService accountService, IEmailSender emailSender)
        {
            _accountService = accountService;
            _emailSender = emailSender;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Register([FromForm] RegisterViewModel model)
        {
            if (model.Username.Length <= 3)
            {
                return BadRequest("User Name Must be Great Than 3");
            }
            else if (model.Password != model.RepeatPassword)
            {
                return BadRequest("RepeatPassword Not Match Password");
            }
            else if (model.EmailAddress != model.RepeatEmailAddress)
            {
                return BadRequest("RepeatEmail Not Match Email Address");
            }
            if (_accountService.RegsiterForm(model).Result)
            {
                var FilePath = $"{Directory.GetCurrentDirectory()}\\Views\\Shared\\MailSentSuccessfully.html";
                var str = new StreamReader(FilePath);
                var mailtext = str.ReadToEnd();
                str.Close();
                _emailSender.SendEmailAsync(model.EmailAddress, "Course Online", mailtext);
                return Ok(model);
            }
            return NotFound("Data incorrect Name or Password");
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([FromForm]LoginViewModel model)
        {
            if (!String.IsNullOrEmpty(model.Email) && !String.IsNullOrEmpty(model.Password))
            {
                if (_accountService.LoginForm(model).Result)
                {
                    return Ok(new { Data = model, Message = "Success" });
                }
            }
            return BadRequest(new { Data = model, Message = "Incorrect Password or Email" });
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult ForgetPassword([FromForm]ForgetPasswordViewModel model)
        {
            if (String.IsNullOrEmpty(model.Email) || String.IsNullOrEmpty(model.Password))
            {
                return BadRequest(new { Data = model, Message = "Incorrect Password or Email" });
            }
            if (_accountService.ForgetPassword(model).Result)
            {
                return Ok(new { Data = model, Message = "Done" });
            }
            return NotFound(new { Data = String.Empty, Message = "Try Again" });
        }
        [HttpGet]
        public IActionResult LogOut()
        {
            if (_accountService.Logout().Result)
            {
                return Ok(new {Message = "Done" });
            }
            return NotFound(new { Message = "Try Again" });
        }
    }
   
}


