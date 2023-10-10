using Course.dashboard.Areas.UI.GateWay.Services;
using Microsoft.AspNetCore.Mvc;

namespace Course.dashboard.Areas.UI.Controllers {
    [Area("UI")]
    public class PaymentController :Controller {
        private readonly IStripeService _stripeService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public PaymentController(IStripeService stripeService, IHttpContextAccessor httpContextAccessor)
        {
            _stripeService = stripeService;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpGet]
        public async Task<IActionResult> GateWay()
        {

            int Amount = 1299;
            var url =await _stripeService.OnlinePaymentStripe(Amount);
            return Redirect(url);
        }
    }
}
