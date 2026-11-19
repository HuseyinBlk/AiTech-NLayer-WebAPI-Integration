using System.Text.Json;
using AiTech.WebUI.DTOs.CategoryDtos;
using AiTech.WebUI.Services.BaseServices;

namespace AiTech.WebUI.Services.CategoryServices;

public class CategoryService(HttpClient httpClient) : BaseApiService<ResultCategoryDto, CreateCategoryDto,UpdateCategoryDto>(httpClient,"Categories"),ICategoryService
{ 
    
}