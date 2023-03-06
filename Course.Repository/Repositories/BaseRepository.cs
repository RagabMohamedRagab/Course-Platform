
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

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
           _dbSet.Remove(entity);
        }

        public T Find(Expression<Func<T, bool>> expression)
        {
        return  _dbSet.SingleOrDefault(expression);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet;
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
