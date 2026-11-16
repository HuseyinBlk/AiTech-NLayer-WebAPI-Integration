using AiTech.DTO.TestimonialDtos;
using AiTech.Entity.Entities;
using AutoMapper;

namespace AiTech.Business.Mappings;

public class TestimonialMapping : Profile
{
    public TestimonialMapping()
    {
        CreateMap<Testimonial, ResultTestimonialDto>().ReverseMap();
        CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();
        CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();
    }
}
