using Course.dashboard.Areas.UI.GateWay.Models;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Checkout;

namespace Course.dashboard.Areas.UI.GateWay.Services {
    public class StripeService : IStripeService {
        private readonly StripeSettings _stripeSettings;

        public StripeService(IOptions<StripeSettings> stripeSettings)
        {
            _stripeSettings = stripeSettings.Value;
        }

        public async Task<string> OnlinePaymentStripe(int Amount)
        {
            StripeConfiguration.ApiKey = _stripeSettings.SecretKey;

            var Options = new SessionCreateOptions()
            {
                PaymentMethodTypes = new List<string>()
                {
                    "card"
                },
                LineItems = new List<SessionLineItemOptions>()
                {
                    new SessionLineItemOptions()
                    {
                        PriceData=new SessionLineItemPriceDataOptions()
                        {
                            Currency=StripeRedirection.Currency,
                            UnitAmount=   Amount,
                             ProductData=new SessionLineItemPriceDataProductDataOptions()
                            {
                                Name="T-Shirt",
                                 Description="Excellent T-Shirt"
                            }
                        },
                        Quantity=20
                    }
                },
                Mode = "payment",
                SuccessUrl = StripeRedirection.SuccessUrl,
                CancelUrl = StripeRedirection.CancelUrl
            };
            var Service = new SessionService();
            var Session = await Service.CreateAsync(Options);
            return Session.Url;
        }
    }
}
