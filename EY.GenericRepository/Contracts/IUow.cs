using Microsoft.EntityFrameworkCore;

namespace EY.GenericRepository.Contracts;

public interface IUow
{
    IReadRepository<T> GetReadRepository<T>() where T : class;
    IBaseRepository<T> GetBaseRepository<T>() where T : class;
    IRepository<T> GetRepository<T>() where T : class;
    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    void BeginTransaction();
    Task BeginTransactionAsync(CancellationToken cancellationToken = default);

    void CommitTransaction();
    Task CommitTransactionAsync(CancellationToken cancellationToken = default);

    bool IsInTransaction();
    Task<bool> IsInTransactionAsync(CancellationToken cancellationToken = default);

    void RollbackTransaction();
    Task RollbackTransactionAsync(CancellationToken cancellationToken = default);

}