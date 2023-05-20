
using Course.Repository.IRepositories;
using Course.Repository.ViewModeles;

namespace Course.Service.Services {
    public class TitleService: ITitleService {
        private readonly ITitleRepository _titleRepository;

        public TitleService(ITitleRepository titleRepository)
        {
            _titleRepository = titleRepository;
        }

        public void Create(TitleFormViewModel title)
        {
          
        }
    }
}
