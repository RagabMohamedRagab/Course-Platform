using AutoMapper;
using Course.Domain.Domains;
using Course.Repository.IRepositories;
using Course.Repository.ViewModeles;
using Course.Service.Utilities;

namespace Course.Service.Services {
    public class CourseService : ICourseService {
        private readonly ICourseRepository _course;
      

        private readonly IFileService _fileService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CourseService(ICourseRepository course, IMapper mapper, IFileService fileService, IUnitOfWork unitOfWork)
        {
            _course = course;
            _mapper = mapper;
            _fileService = fileService;
            _unitOfWork = unitOfWork;
        
        }

        public async Task<bool> AddCourse(CourseViewModel model)
        {
            var courseModel = model.course;
            // Test Case 1 Course !=Null Or TitleId ! =0
            if (courseModel is null)
                return false;
            // Test Case 2 try catch 
            try
            {
                var courseDb = _mapper.Map<Course.Domain.Domains.Course>(courseModel);
                courseDb.Logo = courseModel.Logo.FileName;
                // Create Instance In Memmory 
                await _course.Add(courseDb);
                if (await _unitOfWork.SaveChangesAsync() > 0&& await _fileService.UploadFile(courseModel.Logo, Utitity.Course)) // Saving In Db
                    return true;
                // Test Case 3 User is Exists or Not
                return false;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public async Task<DisplayAllVideos> GetAllVideosById(int id)
        {
            var DisplayVideoes = new DisplayAllVideos();
            if (id == 0)
                return DisplayVideoes;
            var GetAllTitles =await _course.GetAll();
            var GetTitlesById = GetAllTitles.Where(b => b.TitleId == id);
             foreach(var course in GetTitlesById)
            {
                var video=_mapper.Map<CoursesViewModel>(course);
                DisplayVideoes.Courses.Add(video);
            }
            DisplayVideoes.IsCompleted = true;
             return DisplayVideoes;
        }
    }
}
