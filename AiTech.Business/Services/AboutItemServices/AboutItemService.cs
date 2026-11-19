using AiTech.Business.Services.GenericServices;
using AiTech.DataAccess.Repositories.GenericRepositories;
using AiTech.DataAccess.UnitOfWorks;
using AiTech.DTO.AboutItemDtos;
using AiTech.Entity.Entities;

namespace AiTech.Business.Services.AboutItemServices;

public class AboutItemService(IGenericRepository<AboutItem> repository, IUnitOfWork unitOfWork)
    : GenericService<AboutItem, ResultAboutItemDto, CreateAboutItemDto, UpdateAboutItemDto>(repository, unitOfWork), IAboutItemService
{
}
