using AiTech.Business.Services.GenericServices;
using AiTech.DTO.TestimonialDtos;

namespace AiTech.Business.Services.TestimonialServices;

public interface ITestimonialService : IGenericService<ResultTestimonialDto, CreateTestimonialDto, UpdateTestimonialDto>
{
}
