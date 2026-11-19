using AiTech.WebUI.Models;

namespace AiTech.WebUI.Services.BaseServices;

public interface IBaseApiService<TResultDto, TCreateDto, TUpdateDto>
{
    Task<List<TResultDto>> GetAllAsync();
    Task<TResultDto?> GetByIdAsync(int id);
    Task<TUpdateDto?> GetByIdForUpdateAsync(int id);
    Task<ApiResult> CreateAsync(TCreateDto dto);
    Task<ApiResult> UpdateAsync(TUpdateDto dto);
    Task<bool> DeleteAsync(int id);
}