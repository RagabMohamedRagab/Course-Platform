
using Course.Domain.Domains;
using Course.Repository.Context;
using Course.Repository.IRepositories;

namespace Course.Repository.Repositories {
    public class UserCourseRepository : BaseRepository<UserCourse>, IUserCourseRepository {
        public UserCourseRepository(CourseDbContext course) : base(course)
        {
        }
    }
}
