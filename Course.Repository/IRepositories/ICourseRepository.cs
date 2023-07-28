using Course.Domain.Domains;

namespace Course.Repository.IRepositories {
    public interface ICourseRepository:IBaseRepository<Course.Domain.Domains.Course> {
        Task<string> GetUserByName(string Name);
        Task<Course.Domain.Domains.Course> UpdateVideById(int Id);

    }
}
