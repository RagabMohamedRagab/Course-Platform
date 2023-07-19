using Course.Domain.Domains;
using Course.Repository.ViewModeles;

namespace Course.Service.IServices {
    public interface ITitleService {
        Task<bool> Create(TitleFormViewModel title);
        Task<List<TitleDropDownListViewModel>> GetAll();
        Task<DisplayTitlesViewModel> GetAllTitles(int CurrentPage,string userName, string Search = "", string order = "");
        Task<UpdateTitleViewModel> GetTitleById(int id);
        Task<bool> UpdateTitle(UpdateTitleViewModel model);
        Task<bool> DeleteTitle(int Id);
    }
}
