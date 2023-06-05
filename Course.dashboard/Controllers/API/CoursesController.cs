using Course.Repository.ViewModeles;
using Course.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Course.dashboard.Controllers.API {
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CoursesController : ControllerBase {
        private readonly ITitleService _titleService;
        private readonly ICourseService _courseService;
        public CoursesController(ITitleService titleService, ICourseService courseService)
        {
            _titleService = titleService;
            _courseService = courseService;
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Title([FromForm] TitleFormViewModel title)
        {
            if (!ModelState.IsValid)
                return BadRequest("Incorrect Data");
            if (!await _titleService.Create(title))
                return NotFound("Incorret Data");

            return Ok("Sucess");

        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] CourseViewModel model)
        {
            return await _courseService.AddCourse(model) ? Ok() : NotFound(new { Message = "Data Not Found" });
        }
    }
}
