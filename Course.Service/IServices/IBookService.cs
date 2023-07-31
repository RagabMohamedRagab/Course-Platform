
using Course.Repository.ViewModeles;

namespace Course.Service.IServices {
    public interface IBookService {
        Task<bool> CreateAsync(BookFormViewModel model);
    }
}
