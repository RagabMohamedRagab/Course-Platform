

using Course.Domain.Domains;
using Course.Repository.Context;
using Course.Repository.IRepositories;

namespace Course.Repository.Repositories {
    public class CourseRepository : BaseRepository<Course.Domain.Domains.Course>, ICourseRepository {
        public CourseRepository(CourseDbContext course) : base(course)
        {
        }
    }
}
