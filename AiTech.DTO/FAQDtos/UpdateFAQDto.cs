using AiTech.DTO.Common;

namespace AiTech.DTO.FAQDtos;

public record UpdateFAQDto(int Id, string Question, string Answer) : IBaseDto;
