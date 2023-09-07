
using AutoMapper;
using Course.Repository.IRepositories;
using Course.Repository.ViewModeles;

namespace Course.Service.Services {
    public class ContactService : IContactService {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public ContactService(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ContactUsViewModel>> GetContactUsAsync()
        {
            var Msg =await _contactRepository.GetAll();
             return _mapper.Map<IEnumerable<ContactUsViewModel>>(Msg);
        }
    }
}
