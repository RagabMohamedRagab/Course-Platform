using Course.dashboard.Areas.UI.GateWay.Services;
using Microsoft.AspNetCore.Mvc;

namespace Course.dashboard.Areas.UI.Controllers {
    [Area("UI")]
    public class PaymentController :Controller {
        private readonly IStripeService _stripeService;

        public PaymentController(IStripeService stripeService)
        {
            _stripeService = stripeService;
        }

        public async Task<IActionResult> GateWay(int amount)
        {
            var url =await _stripeService.OnlinePaymentStripe(amount);
            return Redirect(url);
        }
    }
}
