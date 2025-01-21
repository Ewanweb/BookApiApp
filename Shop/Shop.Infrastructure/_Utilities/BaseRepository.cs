using System.Linq.Expressions;
using Common.Domain;
using Common.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.EF;

namespace Shop.Infrastructure._Utilities;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    private readonly ShopContext context;
    public BaseRepository(ShopContext context)
    {
        context = context;
    }

    public virtual async Task<TEntity?> GetAsync(long id)
    {
        return await context.Set<TEntity>().FirstOrDefaultAsync(t => t.Id.Equals(id)); ;
    }
    public async Task<TEntity?> GetTracking(long id)
    {
        return await context.Set<TEntity>().AsTracking().FirstOrDefaultAsync(t => t.Id.Equals(id));

    }
    public async Task AddAsync(TEntity entity)
    {
        await context.Set<TEntity>().AddAsync(entity);
    }

    void IBaseRepository<TEntity>.Add(TEntity entity)
    {
        context.Set<TEntity>().Add(entity);
    }
  
    public async Task AddRange(ICollection<TEntity> entities)
    {
        await context.Set<TEntity>().AddRangeAsync(entities);
    }
    public void Update(TEntity entity)
    {
        context.Update(entity);
    }
    public async Task<int> Save()
    {
        return await context.SaveChangesAsync();
    }
    public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await context.Set<TEntity>().AnyAsync(expression);
    }
    public bool Exists(Expression<Func<TEntity, bool>> expression)
    {
        return context.Set<TEntity>().Any(expression);
    }

    public TEntity? Get(long id)
    {
        return context.Set<TEntity>().FirstOrDefault(t => t.Id.Equals(id)); ;
    }
}