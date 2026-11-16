using AiTech.DTO.FAQDtos;
using FluentValidation;

namespace AiTech.Business.Validators.FAQValidators;

public class UpdateFAQValidator : AbstractValidator<UpdateFAQDto>
{
    public UpdateFAQValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Geçersiz SSS ID'si.");

        RuleFor(x => x.Question)
            .NotEmpty().WithMessage("Soru boş bırakılamaz.")
            .MinimumLength(5).WithMessage("Soru en az 5 karakter olmalıdır.")
            .MaximumLength(250).WithMessage("Soru en fazla 250 karakter olabilir.");

        RuleFor(x => x.Answer)
            .NotEmpty().WithMessage("Cevap boş bırakılamaz.")
            .MinimumLength(10).WithMessage("Cevap en az 10 karakter olmalıdır.")
            .MaximumLength(2000).WithMessage("Cevap en fazla 2000 karakter olabilir.");
    }
}
