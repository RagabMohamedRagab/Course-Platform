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
        public async Task<IActionResult> Create([FromForm] CourseFormModelAPI course)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Message="Data Not Found" });
            var model = new CourseViewModel()
            {
                course = new CourseFormViewModel()
                {
                    Description = course.Description,
                    Name = course.Name,
                    Logo = course.File,
                },
                UserName = course.UserName
            };
            return await _courseService.AddCourse(model) ? Ok(new { Message = "Succes" }) : NotFound("Falid");
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Coures(string userName, string? Search = null, string? orderby = null, int currentPage = 1)
        {
            var result = await _titleService.GetAllTitles(currentPage, userName, Search, orderby);
            foreach (var item in result.Titles)
            {
                item.Logo = $"/Images/Title/{item.Logo}";
            }
            return Ok(result);
        }
    }
}
