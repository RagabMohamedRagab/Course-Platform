

using Course.Repository.Context;
using Course.Repository.IRepositories;

namespace Course.Repository.Repositories {
    public class BookRepository : BaseRepository<Book>, IBookRepository {
        public BookRepository(CourseDbContext course) : base(course)
        {
        }
    }
}
