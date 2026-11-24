using AiTech.DataAccess.Context;
using AiTech.DataAccess.Repositories.GenericRepositories;
using AiTech.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace AiTech.DataAccess.Repositories.BannerRepositories;

public class BannerRepository(AppDbContext context) : GenericRepository<Banner>(context), IBannerRepository
{
    public async Task MakeActiveAsync(Banner banner)
    {
        banner.IsActive = true;
    }

    public async Task MakeInactiveAsync(Banner banner)
    {
        banner.IsActive = false;
    }

    public async Task DeactivateAllBannersAsync()
    {
        await DbSet.Where(b => b.IsActive).ExecuteUpdateAsync(setter => setter.SetProperty(b => b.IsActive, false));
    }
}