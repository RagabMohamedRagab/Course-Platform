
namespace Course.Repository.ViewModeles {
	public class CartViewModel {
		public int CartId { get; set; }
		public int Id { get; set; }
		public string? img { get;set; }
		public int Quantity { get;set; }
		public string? Name { get;set; }
		public decimal QantityFPrice { get; set; }
		public decimal Price { get; set; }
		public string type { get;set; }

	}
}
