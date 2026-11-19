using AiTech.DTO.Common;

namespace AiTech.DTO.TestimonialDtos;

public record ResultTestimonialDto(
    int Id,
    string FullName,
    string Title,
    string Comment,
    string ImageUrl,
    DateTime CreatedDate,
    DateTime? UpdatedDate) : IBaseDto;
