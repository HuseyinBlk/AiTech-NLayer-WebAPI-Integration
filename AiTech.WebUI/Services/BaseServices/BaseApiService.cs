using System.Net;
using AiTech.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AiTech.WebUI.Services.BaseServices;

public class BaseApiService<TResultDto,TCreateDto,TUpdateDto>(HttpClient httpClient,string endpoint) : IBaseApiService<TResultDto,TCreateDto,TUpdateDto>
{
    public async Task<List<TResultDto>> GetAllAsync()
    {
        return await httpClient.GetFromJsonAsync<List<TResultDto>>(endpoint);
    }

    public async Task<TResultDto?> GetByIdAsync(int id)
    {
        return await httpClient.GetFromJsonAsync<TResultDto>($"{endpoint}/{id}");
    }

    public async Task<TUpdateDto?> GetByIdForUpdateAsync(int id)
    {
        return await httpClient.GetFromJsonAsync<TUpdateDto>($"{endpoint}/{id}");
    }

    public async Task<ApiResult> CreateAsync(TCreateDto dto)
    {
        var response = await httpClient.PostAsJsonAsync(endpoint, dto);

        if (response.IsSuccessStatusCode)
        {
            return ApiResult.Success();
        }

        if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            var problemDetails = await response.Content.ReadFromJsonAsync<ValidationProblemDetails>();
            return ApiResult.Fail(problemDetails?.Errors);
        }
        
        return ApiResult.Fail(null,"Ekleme sırasında hata oluştu.");
    }

    public async Task<ApiResult> UpdateAsync(TUpdateDto dto)
    {
        var response = await httpClient.PutAsJsonAsync(endpoint, dto);

        if (response.IsSuccessStatusCode)
        {
            return ApiResult.Success();
        }

        if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            var problemDetails = await response.Content.ReadFromJsonAsync<ValidationProblemDetails>();
            
            return ApiResult.Fail(problemDetails?.Errors);
        }
        
        return ApiResult.Fail(null,"Güncelleme sırasında hata oluştu.");
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await httpClient.DeleteAsync($"{endpoint}/{id}");
        return response.IsSuccessStatusCode;
    }
}