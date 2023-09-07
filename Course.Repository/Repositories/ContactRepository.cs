

using Course.Repository.Context;
using Course.Repository.IRepositories;

namespace Course.Repository.Repositories {
    public class ContactRepository : BaseRepository<ContactUs>, IContactRepository {
        public ContactRepository(CourseDbContext course) : base(course)
        {
        }

    
    }
}
