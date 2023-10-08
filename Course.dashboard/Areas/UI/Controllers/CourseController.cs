using Microsoft.AspNetCore.Mvc;

namespace Course.dashboard.Areas.UI.Controllers {
	[Area("UI")]
	public class CourseController : Microsoft.AspNetCore.Mvc.Controller {
		private readonly ICourseUIRepository _courseUIRepository;

		public CourseController(ICourseUIRepository courseUIRepository)
		{
			_courseUIRepository = courseUIRepository;
		}

		[HttpGet]
		public async Task<IActionResult> Gourmet(string Search, string orderby, int currentPage = 1, int pSize = 3)
		{
			return View(await _courseUIRepository.DisplayTitles(currentPage, pSize, Search, orderby));
		}
	}
}
