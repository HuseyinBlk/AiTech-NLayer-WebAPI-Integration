using AiTech.DTO.Common;

namespace AiTech.DTO.AboutItemDtos;

public record ResultAboutItemDto(
    int Id,
    string Text,
    DateTime CreatedDate,
    DateTime? UpdatedDate) : IBaseDto;
