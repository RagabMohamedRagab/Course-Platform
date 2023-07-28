using Course.Repository.ViewModeles;

namespace Course.Service.IServices {
    public interface ICourseService {
        Task<bool> AddCourse(CourseViewModel model);
        Task<DisplayAllVideos> GetAllVideosById(int id);
        Task<IList<VideosJsonViewModel>> GetAllVideosJsonById(int id, int currentPage, int pageSize);
        Task<bool> DeleteVideo(int id);
        Task<VideoByIdViewModel> GetVideoById(int id);
        Task<bool> UpdateVideo(VideoByIdViewModel model);
        
    }
}
