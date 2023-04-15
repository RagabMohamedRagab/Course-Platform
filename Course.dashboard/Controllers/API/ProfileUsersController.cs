using Course.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Course.dashboard.Controllers.API {
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProfileUsersController : ControllerBase {
        private readonly IAccountService _accountService;

        public ProfileUsersController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Profile(string email)
        {
            var result=_accountService.ProfileUser(email);
            if(result == null)
            {
                return NotFound(new { Data = result, Message = "Your Request Falied" });
            }
            return Ok(new { Data = result, Message = "Done" });
        }
    }
}
