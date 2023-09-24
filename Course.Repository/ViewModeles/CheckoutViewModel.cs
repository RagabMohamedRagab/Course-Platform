
namespace Course.Repository.ViewModeles {
	public class CheckoutViewModel {
		public CheckoutViewModel()
		{
			IsCompleted = false;
			CartViewModels=new List<CartViewModel>();
		}
		public IList<CartViewModel> CartViewModels { get; set; }

		public decimal Discount { get;set; }  
		public decimal TotalPrice { get;set; }

		public bool IsCompleted { get;set; }
	}
}
