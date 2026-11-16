using AiTech.DTO.Common;

namespace AiTech.DTO.ProjectDtos;

public record UpdateProjectDto(int Id, string Title, string ImageUrl, int CategoryId) : IBaseDto;
