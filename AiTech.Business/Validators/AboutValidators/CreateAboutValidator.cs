using AiTech.DTO.AboutDtos;
using FluentValidation;

namespace AiTech.Business.Validators.AboutValidators;

public class CreateAboutValidator : AbstractValidator<CreateAboutDto>
{
    public CreateAboutValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Başlık boş bırakılamaz.")
            .MinimumLength(5).WithMessage("Başlık en az 5 karakter olmalıdır.")
            .MaximumLength(150).WithMessage("Başlık en fazla 150 karakter olabilir.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Açıklama boş bırakılamaz.")
            .MinimumLength(20).WithMessage("Açıklama en az 20 karakter olmalıdır.")
            .MaximumLength(2000).WithMessage("Açıklama en fazla 2000 karakter olabilir.");

        RuleFor(x => x.ButtonText)
            .NotEmpty().WithMessage("Buton metni boş bırakılamaz.")
            .MinimumLength(2).WithMessage("Buton metni en az 2 karakter olmalıdır.")
            .MaximumLength(30).WithMessage("Buton metni en fazla 30 karakter olabilir.");

        RuleFor(x => x.ButtonUrl)
            .NotEmpty().WithMessage("Buton linki boş bırakılamaz.")
            .MaximumLength(250).WithMessage("Buton linki en fazla 250 karakter olabilir.");

        RuleFor(x => x.ImageUrl)
            .NotEmpty().WithMessage("Görsel linki boş bırakılamaz.")
            .MaximumLength(250).WithMessage("Görsel linki en fazla 250 karakter olabilir.");
    }
}
