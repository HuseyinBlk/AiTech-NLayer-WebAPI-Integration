using AiTech.Business.Exceptions;
using AiTech.Business.Services.GenericServices;
using AiTech.DataAccess.Repositories.BannerRepositories;
using AiTech.DataAccess.Repositories.GenericRepositories;
using AiTech.DataAccess.UnitOfWorks;
using AiTech.DTO.BannerDtos;
using AiTech.Entity.Entities;

namespace AiTech.Business.Services.BannerServices;

public class BannerService(
    IBannerRepository repository, 
    IUnitOfWork unitOfWork)
    : GenericService<Banner, ResultBannerDto, CreateBannerDto, UpdateBannerDto>(repository, unitOfWork),IBannerService
{
    public async Task MakeActiveAsync(int bannerId)
    {
        await repository.DeactivateAllBannersAsync();
        var banner = await Repository.GetByIdAsync(bannerId);
        if (banner == null)
        {
            throw new NotFoundException("Banner bulunamadı.");
        }
        await repository.MakeActiveAsync(banner);
        await UnitOfWork.SaveAsync();
    }

    public async Task MakeInactiveAsync(int bannerId)
    {
        var banner = await Repository.GetByIdAsync(bannerId);
        if (banner == null)
        {
            throw new NotFoundException("Banner bulunamadı.");
        }
        await repository.MakeInactiveAsync(banner);
        await UnitOfWork.SaveAsync();
    }
}
