using Course.Repository.ViewModeles;

namespace Course.Service.IServices {
    public interface ICourseService {
        Task<bool> AddCourse(CourseViewModel model);
        Task<DisplayAllVideos> GetAllVideosById(int id);
        Task<bool> DeleteVideo(int id);
        Task<VideoByIdViewModel> GetVideoById(int id);
    }
}
