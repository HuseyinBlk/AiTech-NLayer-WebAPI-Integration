using AiTech.Business.Services.GenericServices;
using AiTech.DTO.BannerDtos;
using AiTech.Entity.Entities;

namespace AiTech.Business.Services.BannerServices;

public interface IBannerService : IGenericService<ResultBannerDto, CreateBannerDto, UpdateBannerDto>
{
    Task MakeActiveAsync(int bannerId);
    Task MakeInactiveAsync(int bannerId);
}
