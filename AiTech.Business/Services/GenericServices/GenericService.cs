using AiTech.Business.Exceptions;
using AiTech.DataAccess.Repositories.GenericRepositories;
using AiTech.DataAccess.UnitOfWorks;
using AiTech.DTO.Common;
using AiTech.Entity.Entities.Common;
using Mapster;
using MapsterMapper;

namespace AiTech.Business.Services.GenericServices;

public class GenericService<TEntity, TResultDto, TCreateDto, TUpdateDto>(
    IGenericRepository<TEntity> repository,
    IUnitOfWork unitOfWork)
    : IGenericService<TResultDto, TCreateDto, TUpdateDto> 
    where TEntity : BaseEntity 
    where TUpdateDto : IBaseDto
{
    protected readonly IGenericRepository<TEntity> Repository = repository;
    protected readonly IUnitOfWork UnitOfWork = unitOfWork;
    
    
    public async Task<List<TResultDto>> GetAllAsync()
    {
        var entities = await Repository.GetAllAsync();
        return entities.Adapt<List<TResultDto>>();
    }

    public async Task<TResultDto> GetByIdAsync(int id)
    {
        var entity = await Repository.GetByIdAsync(id);
        if (entity == null)
        {
            throw new NotFoundException("İlgili kayıt bulunamadı.");
        }
        return entity.Adapt<TResultDto>();
    }

    public async Task CreateAsync(TCreateDto createDto)
    {
        var entity = createDto.Adapt<TEntity>();
        await Repository.CreateAsync(entity);
        await UnitOfWork.SaveAsync();
    }

    public async Task UpdateAsync(TUpdateDto updateDto)
    {
        var entity = await Repository.GetByIdAsync(updateDto.Id);
        if (entity == null)
        {
            throw new NotFoundException("Güncellenecek kayıt bulunamadı.");
        }
        updateDto.Adapt(entity);
        Repository.Update(entity);
        await UnitOfWork.SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await Repository.GetByIdAsync(id);
        if (entity == null)
        {
            throw new NotFoundException("Silinecek kayıt bulunamadı.");
        }
        Repository.Delete(entity);
        await UnitOfWork.SaveAsync();
    }
}