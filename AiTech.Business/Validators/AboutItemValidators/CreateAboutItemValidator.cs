using AiTech.DTO.AboutItemDtos;
using FluentValidation;

namespace AiTech.Business.Validators.AboutItemValidators;

public class CreateAboutItemValidator : AbstractValidator<CreateAboutItemDto>
{
    public CreateAboutItemValidator()
    {
        RuleFor(x => x.Text)
            .NotEmpty().WithMessage("Madde metni boş bırakılamaz.")
            .MinimumLength(3).WithMessage("Madde metni en az 3 karakter olmalıdır.")
            .MaximumLength(100).WithMessage("Madde metni en fazla 100 karakter olabilir.");
    }
}
