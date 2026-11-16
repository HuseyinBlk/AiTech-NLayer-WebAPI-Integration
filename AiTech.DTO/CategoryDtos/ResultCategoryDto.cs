using AiTech.DTO.Common;

namespace AiTech.DTO.CategoryDtos;

public record ResultCategoryDto(int Id, string Title, DateTime CreatedDate) : IBaseDto;