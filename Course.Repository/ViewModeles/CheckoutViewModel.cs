
namespace Course.Repository.ViewModeles {
	public class CheckoutViewModel {
		public CheckoutViewModel()
		{
			IsCompleted = false;
			CartViewModels=new List<CartViewModel>();
		}
		public IList<CartViewModel> CartViewModels { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public decimal Discount { get;set; }  
		public decimal TotalPrice { get;set; }
		public int Totaldata { get;set; }

		public bool IsCompleted { get;set; }
	}
}
