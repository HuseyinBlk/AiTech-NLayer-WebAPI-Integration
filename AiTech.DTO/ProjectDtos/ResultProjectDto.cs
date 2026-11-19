using AiTech.DTO.CategoryDtos;
using AiTech.DTO.Common;

namespace AiTech.DTO.ProjectDtos;

public record ResultProjectDto(
    int Id,
    string Title,
    string ImageUrl,
    int CategoryId,
    ResultCategoryDto? Category,
    DateTime CreatedDate,
    DateTime? UpdatedDate) : IBaseDto;
