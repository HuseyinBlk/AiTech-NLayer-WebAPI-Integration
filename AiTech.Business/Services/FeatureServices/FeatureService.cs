using AiTech.Business.Services.GenericServices;
using AiTech.DataAccess.Repositories.GenericRepositories;
using AiTech.DataAccess.UnitOfWorks;
using AiTech.DTO.FeatureDtos;
using AiTech.Entity.Entities;

namespace AiTech.Business.Services.FeatureServices;

public class FeatureService(IGenericRepository<Feature> repository, IUnitOfWork unitOfWork)
    : GenericService<Feature, ResultFeatureDto, CreateFeatureDto, UpdateFeatureDto>(repository, unitOfWork), IFeatureService
{
}
