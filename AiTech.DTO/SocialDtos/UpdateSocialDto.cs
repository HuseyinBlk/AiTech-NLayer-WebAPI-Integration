using AiTech.DTO.Common;

namespace AiTech.DTO.SocialDtos;

public record UpdateSocialDto(int Id, string Name, string Icon, string Url) : IBaseDto;
