using AiTech.DTO.SocialDtos;
using AiTech.Entity.Entities;
using AutoMapper;

namespace AiTech.Business.Mappings;

public class SocialMapping : Profile
{
    public SocialMapping()
    {
        CreateMap<Social, ResultSocialDto>().ReverseMap();
        CreateMap<Social, CreateSocialDto>().ReverseMap();
        CreateMap<Social, UpdateSocialDto>().ReverseMap();
    }
}
