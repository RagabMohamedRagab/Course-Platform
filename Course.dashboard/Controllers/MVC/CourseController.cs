using Course.Domain.Domains;
using Course.Repository.ViewModeles;
using Microsoft.AspNetCore.Mvc;

namespace Course.dashboard.Controllers.MVC {
    public class CourseController : Controller {
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
                Title=new TitleFormViewModel(),
                Titles = new List<string>() {}
            };
            return View(Course);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Title(TitleFormViewModel title)
        {
            return View();
        }
    }
}
