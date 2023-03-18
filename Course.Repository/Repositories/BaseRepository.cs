
using Course.Repository.Context;
using Course.Repository.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Course.Repository.Repositories {
    public class BaseRepository<T> : IBaseRepository<T> where T : class {

        private readonly CourseDbContext _course;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(CourseDbContext course)
        {
            _course = course;
            _dbSet = course.Set<T>();
        }

        public async Task Add(T entity)
        {
            await _dbSet.AddAsync(entity);
      
        }

        public async Task Delete(T entity)
        {
           _dbSet.Remove(entity);
        }

        public async Task<T> Find(Expression<Func<T, bool>> expression)
        {
        return  await _dbSet.SingleOrDefaultAsync(expression);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public  async Task Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
