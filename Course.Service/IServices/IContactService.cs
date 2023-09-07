using Course.Repository.ViewModeles;

namespace Course.Service.IServices {
    public interface IContactService {
         public Task<IEnumerable<ContactUsViewModel>> GetContactUsAsync();   
    }
}
