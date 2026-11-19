using AiTech.Business.Services.GenericServices;
using AiTech.DTO.BannerDtos;

namespace AiTech.Business.Services.BannerServices;

public interface IBannerService : IGenericService<ResultBannerDto, CreateBannerDto, UpdateBannerDto>
{
}
