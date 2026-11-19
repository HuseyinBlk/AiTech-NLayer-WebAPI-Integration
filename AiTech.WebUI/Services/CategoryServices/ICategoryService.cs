using AiTech.WebUI.DTOs.CategoryDtos;
using AiTech.WebUI.Services.BaseServices;

namespace AiTech.WebUI.Services.CategoryServices;

public interface ICategoryService : IBaseApiService<ResultCategoryDto,CreateCategoryDto,UpdateCategoryDto>
{
}