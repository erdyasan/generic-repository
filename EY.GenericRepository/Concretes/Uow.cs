using EY.GenericRepository.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace EY.GenericRepository.Concretes;

public sealed class Uow<TDbContext> : IUow where TDbContext : DbContext
{
    private readonly DbContext _dbContext;

    private IDbContextTransaction? _transaction = null;
    public Uow(TDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void BeginTransaction()
    {
        _transaction = _dbContext.Database.BeginTransaction();
    }

    public Task BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        _transaction = _dbContext.Database.BeginTransactionAsync(cancellationToken).Result;
        return Task.CompletedTask;
    }

    public void CommitTransaction()
    {
        _transaction?.Commit();
        _transaction?.Dispose();
        _transaction = null;
    }

    public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (_transaction != null)
        {
            await _transaction.CommitAsync(cancellationToken);
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public IBaseRepository<T> GetBaseRepository<T>() where T : class
    {
        return new BaseRepository<T>(_dbContext);
    }

    public IReadRepository<T> GetReadRepository<T>() where T : class
    {
        return new ReadRepository<T>(_dbContext);
    }

    public IRepository<T> GetRepository<T>() where T : class
    {
        return new Repository<T>(_dbContext);
    }

    public bool IsInTransaction()
    {
        return _transaction != null;
    }

    public Task<bool> IsInTransactionAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult(IsInTransaction());
    }

    public void RollbackTransaction()
    {
        _transaction?.Rollback();
        _transaction?.Dispose();
        _transaction = null;
    }

    public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync(cancellationToken);
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public int SaveChanges()
    {
        return _dbContext.SaveChanges();
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}