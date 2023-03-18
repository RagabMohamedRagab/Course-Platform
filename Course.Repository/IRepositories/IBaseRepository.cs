
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Course.Repository.IRepositories {
    public interface IBaseRepository<T> where T :class {
        public Task Add(T entity);
        public Task Delete(T entity);
        public Task Update(T entity);
        public Task<IEnumerable<T>> GetAll();
        public Task<T> Find(Expression<Func<T, bool>> expression);
    }
}
