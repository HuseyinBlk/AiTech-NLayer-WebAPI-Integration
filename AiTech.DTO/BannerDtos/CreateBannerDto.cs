namespace AiTech.DTO.BannerDtos;

public record CreateBannerDto(
    string Title,
    string Description,
    string LButtonText,
    string LButtonUrl,
    string RButtonText,
    string RButtonUrl,
    string ImageUrl);
