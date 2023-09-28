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

        public async Task<CheckoutViewModel> Checkout(string uname, int Cpage = 1, int Psize = 4, decimal discount = 0.1m)
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
            foreach (var item in cartdata.Where(b => b.UserId == user.Id))
            {
                var cart = new CartViewModel();
                cart.CartId = item.Id;
                if (item.BookId != null)
                {
                    var book = bookdata.Find(b => b.Id == item.BookId);
                    if (book is not null)
                    {
                        var Quantity = cartdata.Where(b => b.BookId == book.Id && b.UserId == user.Id).Count();
                        cart.Id = book.Id;
                        cart.Name = book.Name;
                        cart.img = $"/Images/Book/{book.Cover}";
                        cart.QantityFPrice = book.Price * Quantity;
                        cart.Price = book.Price;
                        cart.Quantity = Quantity;
                        cart.type = "B";
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
                        cart.QantityFPrice = title.Price * Quantity;
                        cart.Price = title.Price;
                        cart.Quantity = Quantity;
                        cart.type = "C";
                    }
                }
                checkout.CartViewModels.Add(cart);
            }
            if (!checkout.CartViewModels.Any())
            {
                checkout.IsCompleted = false;
                return checkout;
            }
            checkout.CartViewModels = checkout.CartViewModels.DistinctBy(b => b.Name).ToList();
            checkout.Discount = discount;                                                                       // 0.1
            checkout.TotalPrice = checkout.CartViewModels.Sum(b => b.Price) * discount;        // price *0.1
            checkout.Totaldata = checkout.CartViewModels.Count;
            int totaldata = checkout.CartViewModels.Count,
                              pagesize = Psize == 0 ? 4 : Psize,
                             //pagesize = 1,
                             currentpage = Cpage == 0 ? 1 : Cpage;
            int totalPages = (int)Math.Ceiling(totaldata / (double)pagesize);

            checkout.CartViewModels = checkout.CartViewModels.Skip((currentpage - 1) * pagesize).Take(pagesize).ToList();
            checkout.CurrentPage = currentpage;
            checkout.PageSize = pagesize;
            checkout.TotalPages = totalPages;

            checkout.IsCompleted = true;
            return checkout;
        }
        public async Task<bool> DeleteCart(int id, string uname)
        {
            var user =await _userManager.FindByEmailAsync(uname);
            if (user is null) return false;
            var product = _context.Carts.Where(b => (b.UserId == user.Id && b.BookId == id) || (b.UserId == user.Id && b.TitleId == id));
            if (!product.Any()) return false;
            foreach (var item in product)
            {
                _context.Carts.Remove(item);
            }
           await _context.SaveChangesAsync();
            return true;
        }
    }
}
