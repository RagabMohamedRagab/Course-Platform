

using Course.Domain.Domains;
using Course.Repository.Context;
using Course.Repository.IRepositories;
using Microsoft.AspNetCore.Identity;

namespace Course.Repository.Repositories {
    public class TitleRepository : BaseRepository<Title>, ITitleRepository {
        private readonly UserManager<AppUser> _userManager;
        public TitleRepository(CourseDbContext course, UserManager<AppUser> userManager) : base(course)
        {
            _userManager = userManager;
        }

        public async Task<string> GetUserByName(string Name)
        {
            if (String.IsNullOrEmpty(Name))
                return string.Empty;
            var user = await _userManager.FindByNameAsync(Name);
            if (user is not null)
                return user.Id;
            return string.Empty;
        }
    }
}
