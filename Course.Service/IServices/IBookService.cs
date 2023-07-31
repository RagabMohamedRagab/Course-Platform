
using Course.Repository.ViewModeles;

namespace Course.Service.IServices {
    public interface IBookService {
        Task<bool> CreateAsync(BookFormViewModel model);
        Task<IList<DisplayAllBooksViewModel>> GetAllAsync(int currentPage,int pageSize);
       
    }
}
