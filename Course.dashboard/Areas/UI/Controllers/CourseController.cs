using Microsoft.AspNetCore.Mvc;

namespace Course.dashboard.Areas.UI.Controllers {
	[Area("UI")]
	public class CourseController : Controller {

		[HttpGet]
		public IActionResult Gourmet()
		{
			return View();
		}
	}
}
