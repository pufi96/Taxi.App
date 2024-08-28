using Microsoft.EntityFrameworkCore;
using Taxi.Aplication.Contracts.Persistence;
using Taxi.Domain.Common;

namespace Taxi.Persistence.Repositories;

public class EFBaseRepository<T> : IAsyncRepository<T> where T : AuditableEntity
{
    protected readonly TaxiDbContext _dbContext;

    public EFBaseRepository(TaxiDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual async Task<T> GetByIdAsync(int id)
    {
        return await _dbContext.Set<T>().SingleAsync(x => x.Id == id);
    }

    public async Task<IReadOnlyList<T>> ListAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();

        return entity;
    }

    public async Task UpdateAsync(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Deleted;
        await _dbContext.SaveChangesAsync();
    }
}