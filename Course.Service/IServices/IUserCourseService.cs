using Course.Domain.Domains;

namespace Course.Service.IServices {
    public interface IUserCourseService {
        Task<bool> Add(UserCourse userCourse);
    }
}
