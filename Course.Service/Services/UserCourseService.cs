
using Course.Domain.Domains;
using Course.Repository.IRepositories;

namespace Course.Service.Services {
    public class UserCourseService : IUserCourseService {
        private readonly IUserCourseRepository _userCourseRepository;
        private readonly ICourseRepository _courseRepository; 
        private readonly IUnitOfWork _unitOfWork;

        public UserCourseService(IUserCourseRepository userCourseRepository, IUnitOfWork unitOfWork, ICourseRepository courseRepository)
        {
            _userCourseRepository = userCourseRepository;
            _unitOfWork = unitOfWork;
            _courseRepository = courseRepository;
        }

        public async Task<bool> Add(UserCourse userCourse)
        {
            try
            {
                await _userCourseRepository.Add(userCourse);
                if (await _unitOfWork.SaveChangesAsync() > 0)
                    return true;
                return false;

            }
            catch (Exception)
            {
                return false;

            }
        }

        public async Task GetCourseUserByUserId(string Name, int PageNumber, int PageSize)
        {
            // Test Cas 1 
            if(string.IsNullOrEmpty(Name))
                   return null;
            var user = await _courseRepository.GetUserByName(Name);
            // Test Case 2
            if (user is null)
                return null;
            var allUserCourse =await _userCourseRepository.GetAll();
            // Test Case 3
            if (!allUserCourse.Any())
                return null;
            var getUserCourse = allUserCourse.Where(b => b.UserId == user);
            throw new NotImplementedException();
        }
    }
}
