using Microsoft.AspNetCore.Mvc;

namespace Course.dashboard.Areas.UI.Controllers {
	[Area("UI")]
	public class CourseController : Controller {
		private readonly ICourseUIRepository _courseUIRepository;

		public CourseController(ICourseUIRepository courseUIRepository)
		{
			_courseUIRepository = courseUIRepository;
		}

		[HttpGet]
		public IActionResult Gourmet(string searchby,string orderby,int currentpage = 1, int pSize = 4)
		{
			return View(_courseUIRepository.DisplayTitles(currentpage,pSize,searchby,orderby));
		}
	}
}
