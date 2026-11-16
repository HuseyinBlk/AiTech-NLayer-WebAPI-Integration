using AiTech.DTO.CategoryDtos;
using FluentValidation;

namespace AiTech.Business.Validators.CategoryValidators;

public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryDto>
{
    public UpdateCategoryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Geçersiz kategori ID'si.");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Kategori adı boş bırakılamaz.")
            .MinimumLength(3).WithMessage("Kategori adı en az 3 karakter olmalıdır.")
            .MaximumLength(50).WithMessage("Kategori adı en fazla 50 karakter olabilir.");
    }
}
