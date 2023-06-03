using AutoMapper;
using Course.Domain.Domains;
using Course.Repository.IRepositories;
using Course.Repository.ViewModeles;
using Course.Service.Utilities;

namespace Course.Service.Services {
    public class CourseService : ICourseService {
        private readonly ICourseRepository _course;
        private readonly IUserCourseService _userCourseService;

        private readonly IFileService _fileService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CourseService(ICourseRepository course, IMapper mapper, IFileService fileService, IUnitOfWork unitOfWork, IUserCourseService userCourseService)
        {
            _course = course;
            _mapper = mapper;
            _fileService = fileService;
            _unitOfWork = unitOfWork;
            _userCourseService = userCourseService;
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
                if (!(await _unitOfWork.SaveChangesAsync() > 0 && await _fileService.UploadFile(courseModel.Logo, Utitity.Course)  )) // Saving In Db
                    return false;
                // Test Case 3 User is Exists or Not
                var userId = await _course.GetUserByName(model.UserName);
                if (string.IsNullOrEmpty(userId))
                    return false;
                // Create UserCourseViewModel
                var userCourseVm = new UserCourseViewModel()
                {
                    UserId = userId,
                    CourseId = courseDb.Id
                };
                // Mapper
                var userCourse = _mapper.Map<UserCourse>(userCourseVm);
                if (await _userCourseService.Add(userCourse))
                    return true;
                return false;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
