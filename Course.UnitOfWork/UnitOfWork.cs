
using Course.Repository.Context;

namespace Course.UnitOfWork {
    public class UnitOfWork : IUnitOfWork {
        private readonly CourseDbContext _context;

        public UnitOfWork(CourseDbContext context)
        {
            _context = context;
        }

        public int SaveChanges()
        {
           return _context.SaveChanges();
        } 
        
        
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
