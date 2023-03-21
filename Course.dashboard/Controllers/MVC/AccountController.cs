using Course.Repository.ViewModeles;
using Course.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Course.dashboard.Controllers.MVC {
    public class AccountController : Controller {
        private readonly IAccountService _accountService;
        private readonly IEmailSender _emailSender;
        private readonly IToastNotification _toast;

        public AccountController(IAccountService accountService, IToastNotification toast, IEmailSender emailSender)
        {
            _accountService = accountService;
            _toast = toast;
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public JsonResult ForgetPassword(ForgetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_accountService.ForgetPassword(model).Result)
                {
                    return Json("ok");
                }
            }
            return Json("No");
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model, string? returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (_accountService.LoginForm(model).Result)
                {
                    if (!String.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    _toast.AddSuccessToastMessage("Completed Login");
                    return RedirectToAction("Index", "Home");
                }
            }
            _toast.AddErrorToastMessage("Failed Login");
            ModelState.AddModelError(string.Empty, "Incorrect Password or Email");
            return View(model);
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
                if (_accountService.RegsiterForm(model).Result)
                {
                    var FilePath = $"{Directory.GetCurrentDirectory()}\\Views\\Shared\\MailSentSuccessfully.html";
                    var str = new StreamReader(FilePath);
                    var mailtext = str.ReadToEnd();
                     str.Close();
                    _emailSender.SendEmailAsync(model.EmailAddress, "Course Online", mailtext);
                    _toast.AddSuccessToastMessage("Completed Register");
                    return RedirectToAction("Index", "Home");
                }
            }
            _toast.AddErrorToastMessage("Failed Register");
            return View(model);
        }
        [HttpGet]
        public IActionResult LogOut()
        {
            if (_accountService.Logout().Result)
            {
                _toast.AddSuccessToastMessage("Completed LogOut");
                return RedirectToAction(nameof(Login));
            }
            _toast.AddErrorToastMessage("Failed Logout");
            return RedirectToAction("Index", "Home");
        }

    }
}
