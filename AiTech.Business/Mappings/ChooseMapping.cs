using AiTech.DTO.ChooseDtos;
using AiTech.Entity.Entities;
using AutoMapper;

namespace AiTech.Business.Mappings;

public class ChooseMapping : Profile
{
    public ChooseMapping()
    {
        CreateMap<Choose, ResultChooseDto>().ReverseMap();
        CreateMap<Choose, CreateChooseDto>().ReverseMap();
        CreateMap<Choose, UpdateChooseDto>().ReverseMap();
    }
}
