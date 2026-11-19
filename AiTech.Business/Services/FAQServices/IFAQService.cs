using AiTech.Business.Services.GenericServices;
using AiTech.DTO.FAQDtos;

namespace AiTech.Business.Services.FAQServices;

public interface IFAQService : IGenericService<ResultFAQDto, CreateFAQDto, UpdateFAQDto>
{
}
