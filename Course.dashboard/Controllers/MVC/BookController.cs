using Course.Repository.ViewModeles;
using Course.Service.IServices;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Course.dashboard.Controllers.MVC {
    public class BookController : Controller {
        private readonly IBookService _bookService;
        private readonly IToastNotification _toast;
        public BookController(IBookService bookService, IToastNotification toast)
        {
            _bookService = bookService;
            _toast = toast;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                _toast.AddErrorToastMessage("Data is inCorrect");
                return View(model);
            }
            if(await _bookService.CreateAsync(model))
            {
                _toast.AddSuccessToastMessage("Done");
                return View();
            }
            return View(model);     
            
        }
    }
}
