using AiTech.DTO.AboutItemDtos;
using FluentValidation;

namespace AiTech.Business.Validators.AboutItemValidators;

public class UpdateAboutItemValidator : AbstractValidator<UpdateAboutItemDto>
{
    public UpdateAboutItemValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Geçersiz Madde ID'si.");

        RuleFor(x => x.Text)
            .NotEmpty().WithMessage("Madde metni boş bırakılamaz.")
            .MinimumLength(3).WithMessage("Madde metni en az 3 karakter olmalıdır.")
            .MaximumLength(100).WithMessage("Madde metni en fazla 100 karakter olabilir.");
    }
}
