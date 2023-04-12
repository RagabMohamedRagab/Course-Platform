﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Course.dashboard.Controllers.API {
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileUsersController : ControllerBase {
        [HttpPost]
        public IActionResult Profile()
        {
            return Ok();
        }
    }
}
