using AiTech.Business.Services.GenericServices;
using AiTech.DataAccess.Repositories.GenericRepositories;
using AiTech.DataAccess.UnitOfWorks;
using AiTech.DTO.CategoryDtos;
using AiTech.Entity.Entities;

namespace AiTech.Business.Services.CategoryServices;

public class CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork) : GenericService<Category, ResultCategoryDto, CreateCategoryDto, UpdateCategoryDto>(repository, unitOfWork), ICategoryService
{
    
}