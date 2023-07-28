

using Course.Domain.Domains;
using Course.Repository.Context;
using Course.Repository.IRepositories;
using Microsoft.AspNetCore.Identity;

namespace Course.Repository.Repositories {
    public class CourseRepository : BaseRepository<Course.Domain.Domains.Course>, ICourseRepository {
        private readonly UserManager<AppUser> _userManager;

        public CourseRepository(CourseDbContext course, UserManager<AppUser> userManager) : base(course)
        {
            _userManager = userManager;
        }

        public async Task<string> GetUserByName(string Name)
        {
            if (String.IsNullOrEmpty(Name))
                return string.Empty;
            var user=await _userManager.FindByNameAsync(Name);
            if (user is not null)
                return user.Id;
            return string.Empty;
        }
        public async Task<Course.Domain.Domains.Course> UpdateVideById(int Id)
        {
             var Videos =await GetAll();
            if (!Videos.Any()) return null;
            var VideoById = Videos.SingleOrDefault(b => b.Id == Id);
            if(VideoById is null) return null;
            return VideoById ;
        }
    }
}
