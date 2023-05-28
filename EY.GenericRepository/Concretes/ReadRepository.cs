using System.Linq.Expressions;
using EY.GenericRepository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EY.GenericRepository.Concretes;

public class ReadRepository<T> : BaseRepository<T>, IReadRepository<T>, IBaseRepository<T> where T : class
{
    public ReadRepository(DbContext dbContext) : base(dbContext)
    {
    }
    public int Count(Expression<Func<T, bool>> expression)
    {
        return _dbContext.Set<T>().Count(expression);
    }

    public Task<int> CountAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
    {
        return _dbContext.Set<T>().CountAsync(expression, cancellationToken);
    }

    public bool Exist(Expression<Func<T, bool>> expression)
    {
        return _dbContext.Set<T>().Any(expression);
    }

    public Task<bool> ExistAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
    {
        return _dbContext.Set<T>().AnyAsync(expression, cancellationToken);
    }

    public T First(Expression<Func<T, bool>> expression, bool asNoTracking = true) =>
     asNoTracking ? _dbContext.Set<T>().AsNoTracking().First(expression) : _dbContext.Set<T>().First(expression);

    public Task<T> FirstAsync(Expression<Func<T, bool>> expression, bool asNoTracking = true, CancellationToken cancellationToken = default) =>
    asNoTracking ? _dbContext.Set<T>().AsNoTracking().FirstAsync(expression, cancellationToken) : _dbContext.Set<T>().FirstAsync(expression, cancellationToken);

    public T? FirstOrDefault(Expression<Func<T, bool>> expression, bool asNoTracking = true) => asNoTracking ?
    _dbContext.Set<T>().AsNoTracking().FirstOrDefault(expression) : _dbContext.Set<T>().FirstOrDefault(expression);

    public Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> expression, bool asNoTracking = true, CancellationToken cancellationToken = default) => asNoTracking ? _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(expression, cancellationToken) : _dbContext.Set<T>().FirstOrDefaultAsync(expression, cancellationToken);

    public List<T> GetByCondition(Expression<Func<T, bool>> expression, bool asNoTracking = true, int skip = 0, int take = int.MaxValue)
    {
        if (asNoTracking)
        {
            return _dbContext.Set<T>().AsNoTracking().Where(expression).Skip(skip).Take(take).ToList();
        }
        return _dbContext.Set<T>().Where(expression).Skip(skip).Take(take).ToList();
    }

    public List<T> GetByCondition(IQueryable<T> query, Expression<Func<T, bool>> expression, bool asNoTracking = true, int skip = 0, int take = int.MaxValue)
    {
        if (asNoTracking)
        {
            return query.AsNoTracking().Where(expression).Skip(skip).Take(take).ToList();
        }
        return query.Where(expression).Skip(skip).Take(take).ToList();
    }

    public Task<List<T>> GetByConditionAsync(Expression<Func<T, bool>> expression, bool asNoTracking = true, int skip = 0, int take = int.MaxValue, CancellationToken cancellationToken = default)
    {
        if (asNoTracking)
        {
            return _dbContext.Set<T>().AsNoTracking().Where(expression).AsNoTracking().Skip(skip).Take(take).ToListAsync(cancellationToken);
        }
        return _dbContext.Set<T>().Where(expression).Skip(skip).Take(take).ToListAsync(cancellationToken);
    }

    public Task<List<T>> GetByConditionAsync(IQueryable<T> query, Expression<Func<T, bool>> expression, bool asNoTracking = true, int skip = 0, int take = int.MaxValue, CancellationToken cancellationToken = default)
    {
        if (asNoTracking)
        {
            return query.AsNoTracking().Where(expression).Skip(skip).Take(take).ToListAsync(cancellationToken);
        }
        return query.Where(expression).Skip(skip).Take(take).ToListAsync(cancellationToken);
    }
}