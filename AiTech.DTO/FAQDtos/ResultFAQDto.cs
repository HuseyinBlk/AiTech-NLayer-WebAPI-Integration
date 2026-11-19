using AiTech.DTO.Common;

namespace AiTech.DTO.FAQDtos;

public record ResultFAQDto(
    int Id,
    string Question,
    string Answer,
    DateTime CreatedDate,
    DateTime? UpdatedDate) : IBaseDto;
