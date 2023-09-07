using Course.Service.IServices;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Course.dashboard.Controllers.MVC {
    public class ContactUsController : Controller {
        private readonly IContactService _contactService;
        private readonly IToastNotification _toast;
        public ContactUsController(IContactService contactService, IToastNotification toast)
        {
            _contactService = contactService;
            _toast = toast;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _contactService.GetContactUsAsync());
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            if (!await _contactService.Delete(Id)) 
            {
                _toast.AddErrorToastMessage("Falied");
                return RedirectToAction(nameof(Index));
            }
            _toast.AddSuccessToastMessage("Done");
            return RedirectToAction(nameof(Index));
        }
    }
}
