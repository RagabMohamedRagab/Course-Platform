using Course.Domain.Domains;
using Course.Repository.ViewModeles;
using Course.Service.IServices;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Course.dashboard.Controllers.MVC {
    public class CourseController : Controller {
        private readonly ITitleService _titleService;
        private readonly ICourseService _courseService;

        private readonly IToastNotification _toast;

        public CourseController(ITitleService titleService, IToastNotification toast, ICourseService courseService)
        {
            _titleService = titleService;
            _toast = toast;
            _courseService = courseService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            var Course = new CourseViewModel()
            {
                course = new CourseFormViewModel(),
                Title = new TitleFormViewModel(),
                Titles = _titleService.GetAll().Result
            };
            return View(Course);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CourseViewModel model,string UserId)
        {
            var result = _courseService.AddCourse(model).Result;
            return View();
        }


            [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Title(TitleFormViewModel title)
        {
            if(ModelState.IsValid)
            {
               if(_titleService.Create(title).Result)
                {
                    _toast.AddSuccessToastMessage("Saving Data");
                    return RedirectToAction(nameof(Create));
                }       
            }
            ModelState.AddModelError(string.Empty, "Incoorect Data");
            _toast.AddErrorToastMessage("Enter or Incorrect Data..");
            return RedirectToAction(nameof(Create));
        }
    }
}
