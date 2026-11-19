using AiTech.Business.Services.GenericServices;
using AiTech.DataAccess.Repositories.GenericRepositories;
using AiTech.DataAccess.UnitOfWorks;
using AiTech.DTO.ChooseDtos;
using AiTech.Entity.Entities;

namespace AiTech.Business.Services.ChooseServices;

public class ChooseService(IGenericRepository<Choose> repository, IUnitOfWork unitOfWork)
    : GenericService<Choose, ResultChooseDto, CreateChooseDto, UpdateChooseDto>(repository, unitOfWork), IChooseService
{
}
