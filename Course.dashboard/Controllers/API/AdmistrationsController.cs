using Course.Repository.ViewModeles;
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
        [HttpDelete]
        [AllowAnonymous]
        public IActionResult DeleteRole(string Id)
        {
            var result = _accountService.DeleteRole(Id).Result;
            if (result is null)
            {
                return Ok(new { Data = string.Empty, Message = "Falied Your Request" });
            }
            return Ok(new { Data = result, Message = "Done" });
        }
        [HttpPut]
        [AllowAnonymous]
        public IActionResult EditRole(string Id,string roleName)
        {
            if(_accountService.UpdateRole(Id,roleName).Result != null)
            {
                return Ok(new { Data = new { Id = Id, Name = roleName }, Message = "Success Update" });
            }
            return Ok(new { Data = string.Empty, Message = "Falied Your Request" });
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult EditUserRole(UsersInRoleViewModel model)
        {
            if (model is null || !model.UsersInfo.Any())
            {
                return Ok(new { Data = String.Empty, Message = "Try Again" });
            }

            if (_accountService.UpdateUsersInRole(model).Result)
            {
                return Ok(new { Data = model, Message = "Success Update" });
            }
            return Ok(new { Data = string.Empty, Message = "Falied Your Request" });
        }
    }
}
