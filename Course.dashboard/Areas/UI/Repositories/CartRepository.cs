using Course.Domain.Domains;
using Course.Repository.Context;

namespace Course.dashboard.Areas.UI.Repositories {
    public class CartRepository : ICartRepository {
        private readonly CourseDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public CartRepository(CourseDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<bool> Add(int Id, string UName,string type)
        {
            var user = await _userManager.FindByEmailAsync(UName);
            if (user == null) return false;
            var cart = (type == "C") ? new Cart() { TitleId = Id } : new Cart() { BookId = Id };
            cart.UserId = user.Id;
            _context.Add<Cart>(cart);
            await _context.SaveChangesAsync();
            return true;
        }

		public Task<CheckoutViewModel> Checkout(int Cpage, int Psize)
		{
			throw new NotImplementedException();
		}
	}
}
