using Course.Repository.ViewModeles;

namespace Course.Service.IServices {
    public interface ITitleService {
        Task<bool> Create(TitleFormViewModel title);
    }
}
