

using Course.Domain.Domains;
using Course.Repository.Context;
using Course.Repository.IRepositories;

namespace Course.Repository.Repositories {
    public class TitleRepository : BaseRepository<Title>, ITitleRepository {
        public TitleRepository(CourseDbContext course) : base(course)
        {
        }
    }
}
