namespace AiTech.DTO.AboutDtos;

public record CreateAboutDto(
    string Title,
    string Description,
    string ButtonText,
    string ButtonUrl,
    string ImageUrl);
