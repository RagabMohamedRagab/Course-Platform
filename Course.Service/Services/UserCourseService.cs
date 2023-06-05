
using Course.Domain.Domains;
using Course.Repository.IRepositories;

namespace Course.Service.Services {
    public class UserCourseService : IUserCourseService {
        private readonly IUserCourseRepository _userCourseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserCourseService(IUserCourseRepository userCourseRepository, IUnitOfWork unitOfWork)
        {
            _userCourseRepository = userCourseRepository;
            _unitOfWork = unitOfWork;
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

        public Task GetAllUserById(string id, int PageNumber, int PageSize)
        {
            throw new NotImplementedException();
        }
    }
}
