using Course.Service.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Course.dashboard.Controllers.MVC {
    public class ProfessorController : Controller {
        private readonly IAccountService _accountService;

        public ProfessorController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetProfessorsInfo(int CurrentPage,int PageSize)
        {
            return Json(_accountService.GetProfessors(CurrentPage,PageSize).Result);
        }
    }
}
