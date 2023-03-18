using Course.Repository.ViewModeles;
using Course.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Course.dashboard.Controllers.MVC
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IToastNotification _toast;

        public AccountController(IAccountService accountService, IToastNotification toast)
        {
            _accountService = accountService;
            _toast = toast;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var IsComplete = _accountService.RegsiterForm(model).Result;
                if (IsComplete > 0)
                {
                    _toast.AddSuccessToastMessage("Completed Register");
                    return RedirectToAction("Index", "Home");
                }
            }
            _toast.AddErrorToastMessage("Failed Register");
            return View(model);
        }
    }
}
