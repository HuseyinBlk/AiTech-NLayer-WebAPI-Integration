using AiTech.DTO.Common;

namespace AiTech.DTO.BannerDtos;

public record ResultBannerDto(
    int Id,
    string Title,
    string Description,
    string LButtonText,
    string LButtonUrl,
    string RButtonText,
    string RButtonUrl,
    string ImageUrl,
    bool IsActive,
    DateTime CreatedDate,
    DateTime? UpdatedDate) : IBaseDto;
