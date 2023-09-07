using Course.Service.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Course.dashboard.Controllers.MVC {
    public class ContactUsController : Controller {
        private readonly IContactService _contactService;

        public ContactUsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _contactService.GetContactUsAsync());
        }
    }
}
