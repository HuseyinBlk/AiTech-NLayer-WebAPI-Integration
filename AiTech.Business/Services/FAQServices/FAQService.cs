using AiTech.Business.Services.GenericServices;
using AiTech.DataAccess.Repositories.GenericRepositories;
using AiTech.DataAccess.UnitOfWorks;
using AiTech.DTO.FAQDtos;
using AiTech.Entity.Entities;

namespace AiTech.Business.Services.FAQServices;

public class FAQService(IGenericRepository<FAQ> repository, IUnitOfWork unitOfWork)
    : GenericService<FAQ, ResultFAQDto, CreateFAQDto, UpdateFAQDto>(repository, unitOfWork), IFAQService
{
}
