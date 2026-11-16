using AiTech.DTO.Common;

namespace AiTech.DTO.BannerDtos;

public record UpdateBannerDto(
    int Id,
    string Title,
    string Description,
    string LButtonText,
    string LButtonUrl,
    string RButtonText,
    string RButtonUrl,
    string ImageUrl) : IBaseDto;
