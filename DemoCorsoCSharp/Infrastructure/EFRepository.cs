using Microsoft.EntityFrameworkCore;

namespace DemoCorsoCSharp.Infrastructure;

public class EFRepository<TEntity, TKey>
    : IRepository<TEntity, TKey>
    where TEntity : class, IEntity<TKey>, new()
{
    private readonly DbContext dbContext;
    private readonly DbSet<TEntity> set;

    public EFRepository(DbContext dbContext)
    {
        this.dbContext = dbContext;
        set = dbContext.Set<TEntity>();
    }


    public async Task CreateAsync(TEntity entity)
    {
        set.Add(entity);
        await dbContext.SaveChangesAsync();
        dbContext.Entry(entity).State = EntityState.Detached;
    }

    public async Task DeleteAsync(TKey id)
    {
        var entity = new TEntity { Id = id };
        set.Remove(entity);
        await dbContext.SaveChangesAsync();
    }

    public IQueryable<TEntity> GetAll()
    {
        return set.AsNoTracking();
    }

    public async Task<TEntity?> GetByIdAsync(TKey id)
    {
        var entity = await set.FindAsync(id);
        if(entity == null)
        {
            return null;
        }
        dbContext.Entry(entity).State = EntityState.Detached;

        return entity;
    }

    public async Task UpdateAsync(TEntity entity)
    {
        set.Update(entity);
        await dbContext.SaveChangesAsync();
        dbContext.Entry(entity).State = EntityState.Detached;
    }
}
