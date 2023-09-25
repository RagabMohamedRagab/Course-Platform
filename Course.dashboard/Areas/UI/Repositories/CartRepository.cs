using Course.Domain.Domains;
using Course.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;

namespace Course.dashboard.Areas.UI.Repositories {
	public class CartRepository : ICartRepository {
		private readonly CourseDbContext _context;
		private readonly UserManager<AppUser> _userManager;
		public CartRepository(CourseDbContext context, UserManager<AppUser> userManager)
		{
			_context = context;
			_userManager = userManager;
		}

		public async Task<bool> Add(int Id, string UName, string type)
		{
			var user = await _userManager.FindByEmailAsync(UName);
			if (user == null) return false;
			var cart = (type == "C") ? new Cart() { TitleId = Id } : new Cart() { BookId = Id };
			cart.UserId = user.Id;
			_context.Add<Cart>(cart);
			await _context.SaveChangesAsync();
			return true;
		}

		public async Task<CheckoutViewModel> Checkout(int Cpage, int Psize, decimal discount, string uname)
		{
			var checkout = new CheckoutViewModel();
			// Get Id for User
			var user = await _userManager.FindByEmailAsync(uname);
			if (user is null)
			{
				checkout.IsCompleted = false;
				return checkout;
			}
			// Get Data CART
			var cartdata = await _context.Carts.ToListAsync();
			var titledata = await _context.Titles.ToListAsync();
			var bookdata = await _context.Books.ToListAsync();

			if (!cartdata.Any() || !titledata.Any() || !bookdata.Any())
			{
				checkout.IsCompleted = false;
				return checkout;
			}
			// Add Name and img
			foreach (var item in cartdata.Where(b=>b.UserId==user.Id))
			{
				var cart = new CartViewModel();
				if (item.BookId != null)
				{
					var book = bookdata.Find(b => b.Id == item.BookId);
					if (book is not null)
					{
						var Quantity = cartdata.Where(b => b.BookId == book.Id && b.UserId == user.Id).Count();
						cart.Id = book.Id;
						cart.Name = book.Name;
						cart.img =$"/Images/Book/{book.Cover}";
						cart.Price = book.Price * Quantity;
						cart.Quantity = Quantity;
					}
				}
				else if (item.TitleId != null)
				{
					var title = titledata.Find(b => b.Id == item.TitleId);
					if (title is not null)
					{
						var Quantity = cartdata.Where(b => b.TitleId == title.Id && b.UserId == user.Id).Count();
						cart.Id = title.Id;
						cart.Name = title.Name;
						cart.img = $"/Images/Title/{title.Logo}";
						cart.Price = title.Price * Quantity;
						cart.Quantity = Quantity;
					}
				}
				checkout.CartViewModels.Add(cart);
			}

			checkout.CartViewModels = checkout.CartViewModels.DistinctBy(b=>b.Name).ToList();
			checkout.Discount = discount;                                                                       // 0.1
			checkout.TotalPrice = checkout.CartViewModels.Sum(b => b.Price) * discount;        // price *0.1
            checkout.Totaldata = checkout.CartViewModels.Count;
			int totaldata = checkout.CartViewModels.Count,
							  pagesize = Psize == 0 ? 4 : Psize,
							  //pagesize = 1,
							 currentpage = Cpage == 0 ? 1 : Cpage;
			int totalPages =(int) Math.Ceiling(totaldata / (double)pagesize);

			checkout.CartViewModels = checkout.CartViewModels.Skip((currentpage - 1) * pagesize).Take(pagesize).ToList();
			checkout.CurrentPage = currentpage;
			checkout.PageSize=pagesize;
			checkout.TotalPages = totalPages;
		
			checkout.IsCompleted = true;
			return checkout;
		}
	}
}
