using AiTech.Business.Services.GenericServices;
using AiTech.DataAccess.Repositories.GenericRepositories;
using AiTech.DataAccess.UnitOfWorks;
using AiTech.DTO.TestimonialDtos;
using AiTech.Entity.Entities;

namespace AiTech.Business.Services.TestimonialServices;

public class TestimonialService(IGenericRepository<Testimonial> repository, IUnitOfWork unitOfWork)
    : GenericService<Testimonial, ResultTestimonialDto, CreateTestimonialDto, UpdateTestimonialDto>(repository, unitOfWork), ITestimonialService
{
}
