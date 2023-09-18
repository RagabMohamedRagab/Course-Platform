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

        public async Task<bool> Add(int Id, string UName)
        {
            var user=await _userManager.FindByEmailAsync(UName);
            if (user == null) return false;

            _context.Add<Cart>(new Cart() { TitleId = Id, UserId = user.Id });
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
