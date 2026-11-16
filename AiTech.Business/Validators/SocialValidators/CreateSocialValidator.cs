using AiTech.DTO.SocialDtos;
using FluentValidation;

namespace AiTech.Business.Validators.SocialValidators;

public class CreateSocialValidator : AbstractValidator<CreateSocialDto>
{
    public CreateSocialValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Sosyal medya adı boş bırakılamaz.")
            .MinimumLength(2).WithMessage("Sosyal medya adı en az 2 karakter olmalıdır.")
            .MaximumLength(50).WithMessage("Sosyal medya adı en fazla 50 karakter olabilir.");

        RuleFor(x => x.Icon)
            .NotEmpty().WithMessage("İkon boş bırakılamaz.")
            .MaximumLength(50).WithMessage("İkon en fazla 50 karakter olabilir.");

        RuleFor(x => x.Url)
            .NotEmpty().WithMessage("Profil linki boş bırakılamaz.")
            .MaximumLength(250).WithMessage("Profil linki en fazla 250 karakter olabilir.");
    }
}
