using AiTech.DTO.ChooseDtos;
using FluentValidation;

namespace AiTech.Business.Validators.ChooseValidators;

public class UpdateChooseValidator : AbstractValidator<UpdateChooseDto>
{
    public UpdateChooseValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Geçersiz Seçim ID'si.");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Başlık boş bırakılamaz.")
            .MinimumLength(5).WithMessage("Başlık en az 5 karakter olmalıdır.")
            .MaximumLength(150).WithMessage("Başlık en fazla 150 karakter olabilir.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Açıklama boş bırakılamaz.")
            .MinimumLength(10).WithMessage("Açıklama en az 10 karakter olmalıdır.")
            .MaximumLength(1000).WithMessage("Açıklama en fazla 1000 karakter olabilir.");

        RuleFor(x => x.Item1)
            .NotEmpty().WithMessage("1. Madde boş bırakılamaz.")
            .MaximumLength(100).WithMessage("1. Madde en fazla 100 karakter olabilir.");

        RuleFor(x => x.Item2)
            .NotEmpty().WithMessage("2. Madde boş bırakılamaz.")
            .MaximumLength(100).WithMessage("2. Madde en fazla 100 karakter olabilir.");

        RuleFor(x => x.Item3)
            .NotEmpty().WithMessage("3. Madde boş bırakılamaz.")
            .MaximumLength(100).WithMessage("3. Madde en fazla 100 karakter olabilir.");

        RuleFor(x => x.ImageUrl)
            .NotEmpty().WithMessage("Görsel linki boş bırakılamaz.")
            .MaximumLength(250).WithMessage("Görsel linki en fazla 250 karakter olabilir.");
    }
}
