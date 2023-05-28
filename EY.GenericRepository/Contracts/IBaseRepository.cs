namespace EY.GenericRepository.Contracts;

public interface IBaseRepository<T> where T : class
{
    IQueryable<T> GetQueryAble();
    IQueryable<T> GetQueryableAsNoTracking();
}