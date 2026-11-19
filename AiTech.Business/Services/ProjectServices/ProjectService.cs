using AiTech.Business.Services.GenericServices;
using AiTech.DataAccess.Repositories.GenericRepositories;
using AiTech.DataAccess.UnitOfWorks;
using AiTech.DTO.ProjectDtos;
using AiTech.Entity.Entities;

namespace AiTech.Business.Services.ProjectServices;

public class ProjectService(IGenericRepository<Project> repository, IUnitOfWork unitOfWork)
    : GenericService<Project, ResultProjectDto, CreateProjectDto, UpdateProjectDto>(repository, unitOfWork), IProjectService
{
}
