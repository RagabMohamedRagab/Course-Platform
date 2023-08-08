
using Course.Repository.IRepositories;
using Course.Repository.ViewModeles;
using System.Globalization;

namespace Course.Service.Services {
    public class HomeService : IHomeService {
        private readonly IBookRepository _bookRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly ISubscribeRepository _subscribeRepository;
        private readonly ITitleRepository _titleRepository;

        public HomeService(IBookRepository bookRepository, ICourseRepository courseRepository, ISubscribeRepository subscribeRepository, ITitleRepository titleRepository)
        {
            _bookRepository = bookRepository;
            _courseRepository = courseRepository;
            _subscribeRepository = subscribeRepository;
            _titleRepository = titleRepository;
        }

        public async Task<DisplayDataInHomeViewModel> Index()
        {
            DisplayDataInHomeViewModel model = new DisplayDataInHomeViewModel();
            var countBooks=  await _bookRepository.GetAll();
            var countCourse=await _courseRepository.GetAll();
            var CountSubsrcibe=await _subscribeRepository.GetAll();
            var Courses=await _titleRepository.GetAll();
            model.Books = countBooks.Count();
            model.Courses=countCourse.Count();
            model.TotalSubscribes = CountSubsrcibe.Count();
            List<string> objects=new  List<string>();
            List<int> counts=new  List<int>();
            foreach (var item in Courses)
            {
                objects.Add(item.Name);
                counts.Add(item.Courses.Count);
            }
            model.Months = objects;
            model.Counts= counts;
            return model;
        }
    }
}
