using AiTech.DataAccess.Repositories.GenericRepositories;
using AiTech.Entity.Entities;

namespace AiTech.DataAccess.Repositories.BannerRepositories;

public interface IBannerRepository : IGenericRepository<Banner>
{
    Task MakeActiveAsync(Banner banner);
    Task MakeInactiveAsync(Banner banner);
    Task DeactivateAllBannersAsync();
}