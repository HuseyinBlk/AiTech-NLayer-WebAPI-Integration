using AiTech.DTO.ProjectDtos;
using AiTech.Entity.Entities;
using AutoMapper;

namespace AiTech.Business.Mappings;

public class ProjectMapping : Profile
{
    public ProjectMapping()
    {
        CreateMap<Project, ResultProjectDto>().ReverseMap();
        CreateMap<Project, CreateProjectDto>().ReverseMap();
        CreateMap<Project, UpdateProjectDto>().ReverseMap();
    }
}
