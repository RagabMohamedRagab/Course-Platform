using Microsoft.AspNetCore.Mvc;

namespace Course.dashboard.Areas.UI.Controllers {
    [Area("UI")]
    public class BookController : Microsoft.AspNetCore.Mvc.Controller {
        private readonly IBookUIRepository _bookUIRepository;

        public BookController(IBookUIRepository bookUIRepository)
        {
            _bookUIRepository = bookUIRepository;
        }

        public async Task<IActionResult> Index(string Search, string orderby, int currentPage = 1, int pSize = 3)
        {
            return View(await _bookUIRepository.DisplayBooks(currentPage, pSize, Search, orderby));
        }
    }
}
