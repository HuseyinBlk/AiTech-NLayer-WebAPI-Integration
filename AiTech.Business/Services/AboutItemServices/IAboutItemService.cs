using AiTech.Business.Services.GenericServices;
using AiTech.DTO.AboutItemDtos;

namespace AiTech.Business.Services.AboutItemServices;

public interface IAboutItemService : IGenericService<ResultAboutItemDto, CreateAboutItemDto, UpdateAboutItemDto>
{
}
