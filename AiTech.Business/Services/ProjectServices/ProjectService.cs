using AiTech.Business.Services.GenericServices;
using AiTech.DataAccess.Repositories.GenericRepositories;
using AiTech.DataAccess.Repositories.ProjectRepositories;
using AiTech.DataAccess.UnitOfWorks;
using AiTech.DTO.ProjectDtos;
using AiTech.Entity.Entities;
using Mapster;

namespace AiTech.Business.Services.ProjectServices;

public class ProjectService(IProjectRepository projectRepository, IUnitOfWork unitOfWork)
    : GenericService<Project, ResultProjectDto, CreateProjectDto, UpdateProjectDto>(projectRepository, unitOfWork), IProjectService
{
    public async Task<List<ResultProjectDto>> GetProjectsWithCategoryAsync()
    {
        var projects = await projectRepository.GetProjectsWithCategoryAsync();
        return projects.Adapt<List<ResultProjectDto>>();
    }
}
