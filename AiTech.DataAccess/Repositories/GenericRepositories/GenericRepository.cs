using AiTech.DataAccess.Context;
using AiTech.Entity.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace AiTech.DataAccess.Repositories.GenericRepositories;

public class GenericRepository<TEntity>(AppDbContext context) : IRepositories<TEntity> where TEntity : BaseEntity
{
    public async Task<List<TEntity>> GetAllAsync()
    {
        return await context.Set<TEntity>().AsNoTracking().ToListAsync();
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await context.Set<TEntity>().FindAsync(id);
    }

    public async Task CreateAsync(TEntity entity)
    {
        await context.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        context.Update(entity);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        context.Set<TEntity>().Remove(entity);
        await context.SaveChangesAsync();
    }
}