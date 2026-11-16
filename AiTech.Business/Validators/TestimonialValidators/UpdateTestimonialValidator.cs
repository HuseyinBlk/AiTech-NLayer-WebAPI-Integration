using AiTech.DTO.TestimonialDtos;
using FluentValidation;

namespace AiTech.Business.Validators.TestimonialValidators;

public class UpdateTestimonialValidator : AbstractValidator<UpdateTestimonialDto>
{
    public UpdateTestimonialValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Geçersiz Referans ID'si.");

        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("Ad soyad boş bırakılamaz.")
            .MinimumLength(3).WithMessage("Ad soyad en az 3 karakter olmalıdır.")
            .MaximumLength(70).WithMessage("Ad soyad en fazla 70 karakter olabilir.");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Unvan boş bırakılamaz.")
            .MinimumLength(2).WithMessage("Unvan en az 2 karakter olmalıdır.")
            .MaximumLength(70).WithMessage("Unvan en fazla 70 karakter olabilir.");

        RuleFor(x => x.Comment)
            .NotEmpty().WithMessage("Yorum boş bırakılamaz.")
            .MinimumLength(10).WithMessage("Yorum en az 10 karakter olmalıdır.")
            .MaximumLength(500).WithMessage("Yorum en fazla 500 karakter olabilir.");

        RuleFor(x => x.ImageUrl)
            .NotEmpty().WithMessage("Görsel linki boş bırakılamaz.")
            .MaximumLength(250).WithMessage("Görsel linki en fazla 250 karakter olabilir.");
    }
}
