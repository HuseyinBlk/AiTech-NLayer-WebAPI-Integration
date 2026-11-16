using AiTech.DTO.FeatureDtos;
using AiTech.Entity.Entities;
using AutoMapper;

namespace AiTech.Business.Mappings;

public class FeatureMapping : Profile
{
    public FeatureMapping()
    {
        CreateMap<Feature, ResultFeatureDto>().ReverseMap();
        CreateMap<Feature, CreateFeatureDto>().ReverseMap();
        CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
    }
}
