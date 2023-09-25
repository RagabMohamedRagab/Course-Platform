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
        public async Task<IActionResult> Add(int Id,string UName,string returnUrl,string type)
        {
            if(await _cartRepository.Add(Id, UName,type))
            {
                _toast.AddSuccessToastMessage("Add To Cart ");
                return LocalRedirect(returnUrl);  
            }
            _toast.AddErrorToastMessage("Falied To Add");
            return LocalRedirect(returnUrl);
        }
        [HttpGet]
        public async  Task<IActionResult> Checkout(int currentPage, decimal discound,string uname,int pagesize=4)
        {
            return View(await _cartRepository.Checkout(currentPage, pagesize, discound, uname));
        }
    }
}
