using Course.Repository.ViewModeles;

namespace Course.Service.IServices {
    public interface ICourseService {
        Task<bool> AddCourse(CourseViewModel model);
    }
}
