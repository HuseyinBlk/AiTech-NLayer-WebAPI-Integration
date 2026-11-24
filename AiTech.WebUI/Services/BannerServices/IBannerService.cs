using AiTech.WebUI.DTOs.BannerDtos;
using AiTech.WebUI.Models;
using AiTech.WebUI.Services.BaseServices;

namespace AiTech.WebUI.Services.BannerServices;

public interface IBannerService : IBaseApiService<ResultBannerDto,CreateBannerDto,UpdateBannerDto>
{
    Task<ApiResult> MakeActiveAsync(int id);
    Task<ApiResult> MakeInactiveAsync(int id);
}