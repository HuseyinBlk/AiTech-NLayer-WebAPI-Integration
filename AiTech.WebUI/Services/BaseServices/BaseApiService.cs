using System.Net;
using AiTech.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AiTech.WebUI.Services.BaseServices;

public class BaseApiService<TResultDto,TCreateDto,TUpdateDto>(HttpClient httpClient,string endpoint) : IBaseApiService<TResultDto,TCreateDto,TUpdateDto>
{
    protected readonly HttpClient HttpClient = httpClient;
    public async Task<List<TResultDto>> GetAllAsync()
    {
        return await HttpClient.GetFromJsonAsync<List<TResultDto>>(endpoint);
    }

    public async Task<TResultDto?> GetByIdAsync(int id)
    {
        return await HttpClient.GetFromJsonAsync<TResultDto>($"{endpoint}/{id}");
    }

    public async Task<TUpdateDto?> GetByIdForUpdateAsync(int id)
    {
        return await HttpClient.GetFromJsonAsync<TUpdateDto>($"{endpoint}/{id}");
    }

    public async Task<ApiResult> CreateAsync(TCreateDto dto)
    {
        var response = await HttpClient.PostAsJsonAsync(endpoint, dto);

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
        var response = await HttpClient.PutAsJsonAsync(endpoint, dto);

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
        var response = await HttpClient.DeleteAsync($"{endpoint}/{id}");
        return response.IsSuccessStatusCode;
    }
}