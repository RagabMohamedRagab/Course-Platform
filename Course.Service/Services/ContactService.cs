
using AutoMapper;
using Course.Repository.IRepositories;
using Course.Repository.ViewModeles;

namespace Course.Service.Services {
    public class ContactService : IContactService {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ContactService(IContactRepository contactRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Delete(int id)
        {
            var contact =await  _contactRepository.Find(b => b.Id == id);
            if (contact is null)
                return false;
          await _contactRepository.Delete(contact);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ContactUsViewModel>> GetContactUsAsync()
        {
            var Msg =await _contactRepository.GetAll();
             return _mapper.Map<IEnumerable<ContactUsViewModel>>(Msg);
        }
    }
}
