using EY.GenericRepository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EY.GenericRepository.Concretes;

public class Repository<T> : ReadRepository<T>, IBaseRepository<T>, IReadRepository<T>, IRepository<T> where T : class
{
    public Repository(DbContext dbContext) : base(dbContext)
    {
    }

    public void Add(T entity)
    {
        _dbContext.Set<T>().Add(entity);
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _dbContext.Set<T>().AddAsync(entity, cancellationToken);
    }

    public void AddRange(IEnumerable<T> entities)
    {
        _dbContext.Set<T>().AddRange(entities);
    }

    public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        await _dbContext.Set<T>().AddRangeAsync(entities, cancellationToken);
    }

    public void Put(T entity)
    {
        _dbContext.Set<T>().Update(entity);
    }

    public async Task PutAsync(T entity, CancellationToken cancellationToken = default)
    {
        await Task.Run(() => _dbContext.Set<T>().Update(entity), cancellationToken);
    }

    public void PutRange(IEnumerable<T> entities)
    {
        _dbContext.Set<T>().UpdateRange(entities);
    }

    public async Task PutRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        await Task.Run(() => _dbContext.Set<T>().UpdateRange(entities), cancellationToken);
    }

    public void Delete(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
    }

    public Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        return Task.Run(() => _dbContext.Set<T>().Remove(entity), cancellationToken);
    }

    public void DeleteRange(IEnumerable<T> entities)
    {
        _dbContext.Set<T>().RemoveRange(entities);
    }

    public Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        return Task.Run(() => DeleteRange(entities), cancellationToken);
    }
}