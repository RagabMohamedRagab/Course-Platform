using Course.Domain.Domains;
using Course.Repository.ViewModeles;
using Course.Service.IServices;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Course.dashboard.Controllers.MVC {
    public class CourseController : Controller {
        private readonly ITitleService _titleService;
        private readonly IToastNotification _toast;

        public CourseController(ITitleService titleService, IToastNotification toast)
        {
            _titleService = titleService;
            _toast = toast;
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
            _toast.AddErrorToastMessage("Enter or Incorrect Data..");
            return RedirectToAction(nameof(Create));
        }
    }
}
