﻿using Microsoft.AspNetCore.Mvc;

namespace Course.dashboard.Controllers.MVC {
    public class BookController : Controller {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
    }
}
