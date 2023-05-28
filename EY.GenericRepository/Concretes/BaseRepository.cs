using EY.GenericRepository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EY.GenericRepository.Concretes;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly DbContext _dbContext;
    public BaseRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public IQueryable<T> GetQueryAble()
    {
        return _dbContext.Set<T>().AsQueryable();
    }

    public IQueryable<T> GetQueryableAsNoTracking()
    {
        return _dbContext.Set<T>().AsNoTracking().AsQueryable();
    }
}