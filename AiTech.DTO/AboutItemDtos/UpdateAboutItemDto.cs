using AiTech.DTO.Common;

namespace AiTech.DTO.AboutItemDtos;

public record UpdateAboutItemDto(int Id, string Text) : IBaseDto;
