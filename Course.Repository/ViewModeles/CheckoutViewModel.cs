
namespace Course.Repository.ViewModeles {
	public class CheckoutViewModel {
		public IList<CartViewModel> CartViewModels { get; set; }

		public decimal SubPrice { get;set; }  
		public decimal TotalPrice { get;set; }

		public bool IsCompleted { get;set; }
	}
}
