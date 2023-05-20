using Course.Repository.IRepositories;

public interface IUnitOfWork : IDisposable {
    Task<int> SaveChangesAsync();
}