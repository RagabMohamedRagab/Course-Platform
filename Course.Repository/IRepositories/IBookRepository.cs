

namespace Course.Repository.IRepositories {
    public interface IBookRepository:IBaseRepository<Book> {
        Task<string> GetUserByName(string Name);
        Task<IList<DisplayAllBooksViewModel>> GetAllBooks(int CurrentPage, int Pagesize);
    }
}
