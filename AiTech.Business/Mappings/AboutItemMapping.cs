using AiTech.DTO.AboutItemDtos;
using AiTech.Entity.Entities;
using AutoMapper;

namespace AiTech.Business.Mappings;

public class AboutItemMapping : Profile
{
    public AboutItemMapping()
    {
        CreateMap<AboutItem, ResultAboutItemDto>().ReverseMap();
        CreateMap<AboutItem, CreateAboutItemDto>().ReverseMap();
        CreateMap<AboutItem, UpdateAboutItemDto>().ReverseMap();
    }
}
