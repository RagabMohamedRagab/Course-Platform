using Course.Repository.ViewModeles;
using Course.Service.IServices;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Course.dashboard.Controllers.MVC {
    public class AdmistrationController : Controller {
        private readonly IAccountService _accountService;
        private readonly IToastNotification _toast;

        public AdmistrationController(IAccountService accountService, IToastNotification toast)
        {
            _accountService = accountService;
            _toast = toast;
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
        [HttpPost]
        public IActionResult EditRole(string Id,string Name)
        {
            if(_accountService.UpdateRole(Id,Name).Result is null)
            {
                _toast.AddErrorToastMessage("Failed Update");
                return RedirectToAction(nameof(EditRole),new {Id=Id });
            }
            _toast.AddSuccessToastMessage("Completed Change");
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult EditUserRole(string roleId)
        {
            var role = _accountService.GetRoleById(roleId).Result;

            return View();
        }
    }
}
