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
        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
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
                    return Ok(model);
                }
            }
            return BadRequest("Incorrect Password or Email");
        }
    }
}

