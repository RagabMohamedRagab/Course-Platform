

namespace Course.Repository.IRepositories {
    public interface IBookRepository:IBaseRepository<Book> {
        Task<string> GetUserByName(string Name);
    }
}
