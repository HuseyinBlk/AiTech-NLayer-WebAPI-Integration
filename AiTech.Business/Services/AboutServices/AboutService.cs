using AiTech.Business.Services.GenericServices;
using AiTech.DataAccess.Repositories.GenericRepositories;
using AiTech.DataAccess.UnitOfWorks;
using AiTech.DTO.AboutDtos;
using AiTech.Entity.Entities;

namespace AiTech.Business.Services.AboutServices;

public class AboutService(IGenericRepository<About> repository, IUnitOfWork unitOfWork)
    : GenericService<About, ResultAboutDto, CreateAboutDto, UpdateAboutDto>(repository, unitOfWork), IAboutService
{
}
