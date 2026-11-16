using AiTech.DTO.Common;

namespace AiTech.DTO.AboutDtos;

public record ResultAboutDto(
    int Id,
    string Title,
    string Description,
    string ButtonText,
    string ButtonUrl,
    string ImageUrl,
    DateTime CreatedDate) : IBaseDto;
