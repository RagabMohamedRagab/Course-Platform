
using Course.Domain.Domains;
using Course.Repository.ViewModeles;

namespace Course.Repository.IRepositories {
    public interface IAccountRepository {
          Task<int> Add(RegisterViewModel entity);
    }
}
