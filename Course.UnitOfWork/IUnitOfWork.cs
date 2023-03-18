using Course.Repository.IRepositories;

public interface IUnitOfWork : IDisposable {
 
    int SaveChanges();
}