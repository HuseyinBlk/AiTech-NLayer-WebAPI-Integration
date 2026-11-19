using AiTech.Business.Services.GenericServices;
using AiTech.DTO.FeatureDtos;

namespace AiTech.Business.Services.FeatureServices;

public interface IFeatureService : IGenericService<ResultFeatureDto, CreateFeatureDto, UpdateFeatureDto>
{
}
