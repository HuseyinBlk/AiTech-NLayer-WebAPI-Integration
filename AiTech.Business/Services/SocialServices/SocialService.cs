using AiTech.Business.Services.GenericServices;
using AiTech.DataAccess.Repositories.GenericRepositories;
using AiTech.DataAccess.UnitOfWorks;
using AiTech.DTO.SocialDtos;
using AiTech.Entity.Entities;

namespace AiTech.Business.Services.SocialServices;

public class SocialService(IGenericRepository<Social> repository, IUnitOfWork unitOfWork)
    : GenericService<Social, ResultSocialDto, CreateSocialDto, UpdateSocialDto>(repository, unitOfWork), ISocialService
{
}
