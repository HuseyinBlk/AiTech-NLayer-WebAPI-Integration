using AiTech.Business.Services.GenericServices;
using AiTech.DataAccess.Repositories.GenericRepositories;
using AiTech.DataAccess.UnitOfWorks;
using AiTech.DTO.BannerDtos;
using AiTech.Entity.Entities;

namespace AiTech.Business.Services.BannerServices;

public class BannerService(IGenericRepository<Banner> repository, IUnitOfWork unitOfWork)
    : GenericService<Banner, ResultBannerDto, CreateBannerDto, UpdateBannerDto>(repository, unitOfWork), IBannerService
{
}
