using Course.Repository.Context;
using Course.Repository.IRepositories;
using Microsoft.AspNetCore.Identity;

namespace Course.Repository.Repositories {
    public class SubscribeRepository : BaseRepository<Cart>,ISubscribeRepository {
        private readonly UserManager<AppUser> _user;
        public SubscribeRepository(CourseDbContext course, UserManager<AppUser> user) : base(course)
        {
            _user = user;
        }

        public async Task<List<SubscribeViewModel>> GetSubscribes(string Name)
        {
            // Get UserById
            var userId = await GetUserIdAsync(Name);
            var model = new List<SubscribeViewModel>();
            var Subscribes =await  GetAll();
            var GroupOfGroups = Subscribes.Where(u => u.UserId == userId)
                .GroupBy(x => x.UserId).Select(async b => model.Add(new SubscribeViewModel()
                {
                    Name = await GetName(b.Key),
                    Subscribes = b.Count()
                })).ToList();
            return model;
        }
        private async Task<string> GetName(string userId)
        {
            var user = await _user.FindByIdAsync(userId);
            return user is null ? "":user.Name;
        }
        private async Task<string> GetUserIdAsync(string Name)
        {
            var user =await _user.FindByNameAsync(Name);
            return user?.Id;
        }
    }
}
