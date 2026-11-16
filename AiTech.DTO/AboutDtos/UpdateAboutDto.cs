using AiTech.DTO.Common;

namespace AiTech.DTO.AboutDtos;

public record UpdateAboutDto(
    int Id,
    string Title,
    string Description,
    string ButtonText,
    string ButtonUrl,
    string ImageUrl) : IBaseDto;
