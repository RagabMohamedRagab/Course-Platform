
using System.Linq.Expressions;

namespace Course.Repository.IRepositories {
    public interface IBaseRepository<T> where T :class {
        public void Add(T entity);
        public void Delete(T entity);
        public void Update(T entity);
        public IEnumerable<T> GetAll();
        public T Find(Expression<Func<T, bool>> expression);
    }
}
