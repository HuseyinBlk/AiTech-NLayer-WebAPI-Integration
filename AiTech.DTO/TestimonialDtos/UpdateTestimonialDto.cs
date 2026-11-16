using AiTech.DTO.Common;

namespace AiTech.DTO.TestimonialDtos;

public record UpdateTestimonialDto(int Id, string FullName, string Title, string Comment, string ImageUrl) : IBaseDto;
