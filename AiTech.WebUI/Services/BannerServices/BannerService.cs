using AiTech.WebUI.DTOs.BannerDtos;
using AiTech.WebUI.Models;
using AiTech.WebUI.Services.BaseServices;

namespace AiTech.WebUI.Services.BannerServices;

public class BannerService(HttpClient httpClient) : BaseApiService<ResultBannerDto,CreateBannerDto,UpdateBannerDto>(httpClient, "Banners"),IBannerService
{
    public async Task<ApiResult> MakeActiveAsync(int id)
    {
        var response = await HttpClient.PatchAsync($"Banners/makeActive/{id}",null);
        
        if (!response.IsSuccessStatusCode)
        {
            return ApiResult.Fail(null,"Aktif edilirken hata oluştu, tekrar deneyin.");
        }
        
        return ApiResult.Success();
    }

    public async Task<ApiResult> MakeInactiveAsync(int id)
    {
        var response = await HttpClient.PatchAsync($"Banners/makeInactive/{id}", null);
        
        if (!response.IsSuccessStatusCode)
        {
            return ApiResult.Fail(null,"Inaktif edilirken hata oluştu, tekrar deneyin.");
        }
        
        return ApiResult.Success();
    }
}