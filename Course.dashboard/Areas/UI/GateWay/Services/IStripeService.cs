namespace Course.dashboard.Areas.UI.GateWay.Services {
    public interface IStripeService {
        Task<string> OnlinePaymentStripe(int Amount);
    }
}
