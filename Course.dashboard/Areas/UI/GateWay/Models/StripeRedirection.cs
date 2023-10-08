using Azure;
using Microsoft.AspNetCore.Http;


namespace Course.dashboard.Areas.UI.GateWay.Models
{
    public class StripeRedirection {
        public static string Currency = "EGP";
        public static string SuccessUrl = "https://localhost:7047/UI/Home/Index";
        public static string CancelUrl = "https://localhost:7047/UI/Home/Indexl";
    }
}
