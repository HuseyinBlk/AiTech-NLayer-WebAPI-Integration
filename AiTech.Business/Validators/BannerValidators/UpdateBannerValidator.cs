using AiTech.DTO.BannerDtos;
using FluentValidation;

namespace AiTech.Business.Validators.BannerValidators;

public class UpdateBannerValidator : AbstractValidator<UpdateBannerDto>
{
    public UpdateBannerValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Geçersiz Banner ID'si.");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Başlık boş bırakılamaz.")
            .MinimumLength(5).WithMessage("Başlık en az 5 karakter olmalıdır.")
            .MaximumLength(150).WithMessage("Başlık en fazla 150 karakter olabilir.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Açıklama boş bırakılamaz.")
            .MinimumLength(10).WithMessage("Açıklama en az 10 karakter olmalıdır.")
            .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir.");

        RuleFor(x => x.LButtonText)
            .NotEmpty().WithMessage("Sol buton metni boş bırakılamaz.")
            .MaximumLength(30).WithMessage("Sol buton metni en fazla 30 karakter olabilir.");

        RuleFor(x => x.LButtonUrl)
            .NotEmpty().WithMessage("Sol buton linki boş bırakılamaz.")
            .MaximumLength(250).WithMessage("Sol buton linki en fazla 250 karakter olabilir.");

        RuleFor(x => x.RButtonText)
            .NotEmpty().WithMessage("Sağ buton metni boş bırakılamaz.")
            .MaximumLength(30).WithMessage("Sağ buton metni en fazla 30 karakter olabilir.");

        RuleFor(x => x.RButtonUrl)
            .NotEmpty().WithMessage("Sağ buton linki boş bırakılamaz.")
            .MaximumLength(250).WithMessage("Sağ buton linki en fazla 250 karakter olabilir.");

        RuleFor(x => x.ImageUrl)
            .NotEmpty().WithMessage("Görsel linki boş bırakılamaz.")
            .MaximumLength(250).WithMessage("Görsel linki en fazla 250 karakter olabilir.");
    }
}
