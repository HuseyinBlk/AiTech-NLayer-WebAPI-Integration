using AiTech.DTO.Common;

namespace AiTech.DTO.SocialDtos;

public record ResultSocialDto(int Id, string Name, string Icon, string Url, DateTime CreatedDate) : IBaseDto;
