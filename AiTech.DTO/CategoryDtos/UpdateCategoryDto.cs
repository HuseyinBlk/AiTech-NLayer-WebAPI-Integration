using AiTech.DTO.Common;

namespace AiTech.DTO.CategoryDtos;

public record UpdateCategoryDto(int Id, string Title) : IBaseDto;
