using Course.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;

namespace Course.dashboard.Controllers.API {
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProfessorsController : ControllerBase {
        private readonly IAccountService _accountService;

        public ProfessorsController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetProfessor(int CurrentPage, int Pagesize)
        {
            var result = _accountService.GetProfessors(CurrentPage, Pagesize).Result;
            if (result is null)
            {
                return Ok(new { Data = String.Empty, Status = 200, Message = "NOT Found Data" });
            }
            else
            {
                return Ok(new { Data = result, Status = 200, Message = "Success" });
            }
            
        }
    }
}
