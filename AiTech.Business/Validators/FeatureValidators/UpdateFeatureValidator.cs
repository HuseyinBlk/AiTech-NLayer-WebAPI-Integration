using AiTech.DTO.FeatureDtos;
using FluentValidation;

namespace AiTech.Business.Validators.FeatureValidators;

public class UpdateFeatureValidator : AbstractValidator<UpdateFeatureDto>
{
    public UpdateFeatureValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Geçersiz Özellik ID'si.");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Özellik başlığı boş bırakılamaz.")
            .MinimumLength(3).WithMessage("Özellik başlığı en az 3 karakter olmalıdır.")
            .MaximumLength(100).WithMessage("Özellik başlığı en fazla 100 karakter olabilir.");

        RuleFor(x => x.Icon)
            .NotEmpty().WithMessage("İkon boş bırakılamaz.")
            .MaximumLength(50).WithMessage("İkon en fazla 50 karakter olabilir.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Açıklama boş bırakılamaz.")
            .MinimumLength(10).WithMessage("Açıklama en az 10 karakter olmalıdır.")
            .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir.");
    }
}
