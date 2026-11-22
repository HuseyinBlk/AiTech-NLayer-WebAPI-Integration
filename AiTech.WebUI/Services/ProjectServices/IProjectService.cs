using AiTech.WebUI.DTOs.ProjectDtos;
using AiTech.WebUI.Services.BaseServices;

namespace AiTech.WebUI.Services.ProjectServices;

public interface IProjectService : IBaseApiService<ResultProjectDto,CreateProjectDto,UpdateProjectDto>
{
    Task<List<ResultProjectDto>> GetProjectsWithCategory();
}