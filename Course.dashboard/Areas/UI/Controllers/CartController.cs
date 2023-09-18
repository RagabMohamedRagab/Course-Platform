using Microsoft.AspNetCore.Mvc;
using NToastNotify;

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
        public async Task<IActionResult> AddToCart(int Id,string UName,string returnUrl)
        {
            if(await _cartRepository.Add(Id, UName))
            {
                _toast.AddSuccessToastMessage("Add To Cart ");

            }
            return View();
        }
    }
}
