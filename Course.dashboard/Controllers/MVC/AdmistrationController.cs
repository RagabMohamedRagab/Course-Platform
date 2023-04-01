using Course.Repository.ViewModeles;
using Course.Service.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Course.dashboard.Controllers.MVC {
    public class AdmistrationController : Controller {
        private readonly IAccountService _accountService;

        public AdmistrationController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult Roles()
        {
            var data = _accountService.GetRoles().Result;
            return Json(data);
        }
        [HttpGet]
        
        public JsonResult AddRole(string Name)
        {
            if(! (_accountService.AddRole(Name).Result is null)) {   
                
                return Json("ok");
            }
            return Json("no");
        }
        [HttpGet]
        public JsonResult DeleteRole(string Id)
        {
            if (String.IsNullOrEmpty(Id))
            {
                return Json("no");
            }
            var result=_accountService.DeleteRole(Id).Result;
            if(result is null)
            {
               return Json("no");
            }
            return Json("ok");
        }
        [HttpGet]
        public ActionResult EditRole(string Id)
        {
            var role = _accountService.GetRoleById(Id).Result;
            var usersinRole = _accountService.UserInRole(role.Name).Result;
            EditRoleViewModel model = new EditRoleViewModel()
            {
                role = role,
                UserName = usersinRole
            };
            return View(model);
        }
    }
}
