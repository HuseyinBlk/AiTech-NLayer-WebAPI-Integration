using AiTech.DTO.FAQDtos;
using AiTech.Entity.Entities;
using AutoMapper;

namespace AiTech.Business.Mappings;

public class FAQMapping : Profile
{
    public FAQMapping()
    {
        CreateMap<FAQ, ResultFAQDto>().ReverseMap();
        CreateMap<FAQ, CreateFAQDto>().ReverseMap();
        CreateMap<FAQ, UpdateFAQDto>().ReverseMap();
    }
}
