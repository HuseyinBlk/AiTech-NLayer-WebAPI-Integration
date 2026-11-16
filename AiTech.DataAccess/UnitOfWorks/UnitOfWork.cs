using AiTech.DataAccess.Context;

namespace AiTech.DataAccess.UnitOfWorks;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task<bool> SaveAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }
}