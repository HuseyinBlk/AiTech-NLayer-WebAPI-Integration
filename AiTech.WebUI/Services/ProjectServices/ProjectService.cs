using System.Net.Http.Json;
using AiTech.WebUI.DTOs.ProjectDtos;
using AiTech.WebUI.Services.BaseServices;

namespace AiTech.WebUI.Services.ProjectServices;

public class ProjectService(HttpClient httpClient) 
    : BaseApiService<ResultProjectDto, CreateProjectDto, UpdateProjectDto>(httpClient, "Projects"), IProjectService
{
    public async Task<List<ResultProjectDto>> GetProjectsWithCategory()
    {
        return await HttpClient.GetFromJsonAsync<List<ResultProjectDto>>("Projects/WithCategories");
    }
    
}