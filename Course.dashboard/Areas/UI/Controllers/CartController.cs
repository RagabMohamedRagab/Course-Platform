using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Drawing.Printing;

namespace Course.dashboard.Areas.UI.Controllers {
    [Area("UI")]
    public class CartController : Controller {
        private readonly ICartRepository _cartRepository;
        private readonly IToastNotification _toast;

        public CartController(ICartRepository cartRepository, IToastNotification toast)
        {
            _cartRepository = cartRepository;
            _toast = toast;
        }
        [HttpGet]
        public async Task<IActionResult> Add(int Id, string uname, string returnUrl, string type)
        {
            if (await _cartRepository.Add(Id, uname, type))
            {
                _toast.AddSuccessToastMessage("Add To Cart ");
                return LocalRedirect(returnUrl);
            }
            _toast.AddErrorToastMessage("Falied To Add");
            return LocalRedirect(returnUrl);
        }
        [HttpGet]
        public async Task<IActionResult> Checkout(int currentPage, decimal discound, string uname, int pagesize)
        {
            return View(await _cartRepository.Checkout(uname, currentPage, pagesize, discound));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int Id, string UN)
        {
            if (Id <= 0 || String.IsNullOrEmpty(UN) || !await _cartRepository.DeleteCart(Id, UN))
            {
                _toast.AddErrorToastMessage("UnCorrect");
                return RedirectToAction(nameof(Checkout), new { currentPage = 1, discound = 0.1, uname = UN, pagesize = 4 });
            }
            _toast.AddSuccessToastMessage("Done ");
            return RedirectToAction(nameof(Checkout), new { currentPage = 1, discound = 0.1, uname = UN, pagesize = 4 });
        }
    }
}
