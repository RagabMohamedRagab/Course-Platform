using Microsoft.AspNetCore.Mvc;

namespace Course.dashboard.Areas.UI.Controllers {
	[Area("UI")]
	public class AuthController : Controller {
		public IActionResult Register()
		{
			return View();
		}
		public IActionResult Login()
		{
			return View();
		}
		public IActionResult ContactUs()
		{
			return View();
		}
	}
}
