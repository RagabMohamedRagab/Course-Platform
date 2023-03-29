using Course.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Course.dashboard.Controllers.API {
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdmistrationsController : ControllerBase {
        private readonly IAccountService _accountService;

        public AdmistrationsController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Roles()
        {
            var data = _accountService.GetRoles().Result;
            return Ok(new {Data=data,Message="Successfully Request"});
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult AddRole(string Name)
        {
            var result = _accountService.AddRole(Name).Result;
            if (result is null)
            {
                return Ok(new { Data = string.Empty, Message = "Falied Your Request" });
            }
            return Ok(new { Data = result, Message = "Done" });
        }
    }
}
