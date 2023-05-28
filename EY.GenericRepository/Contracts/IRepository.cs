namespace EY.GenericRepository.Contracts;

public interface IRepository<T> : IReadRepository<T> where T : class
{
    void Add(T entity);
    Task AddAsync(T entity, CancellationToken cancellationToken = default);

    void AddRange(IEnumerable<T> entities);
    Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

    void Put(T entity);
    Task PutAsync(T entity, CancellationToken cancellationToken = default);

    void PutRange(IEnumerable<T> entities);
    Task PutRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

    void Delete(T entity);
    Task DeleteAsync(T entity, CancellationToken cancellationToken = default);

    void DeleteRange(IEnumerable<T> entities);
    Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

}