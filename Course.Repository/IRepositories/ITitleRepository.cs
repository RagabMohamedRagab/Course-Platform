using Course.Domain.Domains;

namespace Course.Repository.IRepositories {
    public interface ITitleRepository:IBaseRepository<Title> {
        Task<string> GetUserByName(string Name);
    }
}
