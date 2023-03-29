﻿using Course.Service.IServices;
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

    }
}