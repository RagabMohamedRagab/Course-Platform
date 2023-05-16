
using Course.Repository.Context;

namespace Course.UnitOfWork {
    public class UnitOfWork : IUnitOfWork {
        private readonly CourseDbContext _context;

        public UnitOfWork(CourseDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChanges()
        {
           return await _context.SaveChangesAsync();
        } 
        
        
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
