using Course.Repository.Context;
using Course.Repository.IRepositories;

namespace Course.Repository.Repositories {
    public class SubscribeRepository : BaseRepository<Subscribe>,ISubscribeRepository {
        public SubscribeRepository(CourseDbContext course) : base(course)
        {
        }
    }
}
