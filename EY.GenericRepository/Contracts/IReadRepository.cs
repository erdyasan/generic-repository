using System.Linq.Expressions;

namespace EY.GenericRepository.Contracts;

public interface IReadRepository<T> : IBaseRepository<T> where T : class
{
    T First(Expression<Func<T, bool>> expression, bool asNoTracking = true);
    Task<T> FirstAsync(Expression<Func<T, bool>> expression, bool asNoTracking = true, CancellationToken cancellationToken = default);

    T? FirstOrDefault(Expression<Func<T, bool>> expression, bool asNoTracking = true);
    Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> expression, bool asNoTracking = true, CancellationToken cancellationToken = default);

    bool Exist(Expression<Func<T, bool>> Expression);
    Task<bool> ExistAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
    int Count(Expression<Func<T, bool>> Expression);
    Task<int> CountAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);

    List<T> GetByCondition(Expression<Func<T, bool>> expression, bool asNoTracking = true, int skip = 0, int take = int.MaxValue);
    Task<List<T>> GetByConditionAsync(Expression<Func<T, bool>> expression, bool asNoTracking = true, int skip = 0, int take = int.MaxValue, CancellationToken cancellationToken = default);

    List<T> GetByCondition(IQueryable<T> query, Expression<Func<T, bool>> expression, bool asNoTracking = true, int skip = 0, int take = int.MaxValue);
    Task<List<T>> GetByConditionAsync(IQueryable<T> query, Expression<Func<T, bool>> expression, bool asNoTracking = true, int skip = 0, int take = int.MaxValue, CancellationToken cancellationToken = default);
}