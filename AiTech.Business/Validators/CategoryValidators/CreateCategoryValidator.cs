using AiTech.DTO.CategoryDtos;
using FluentValidation;

namespace AiTech.Business.Validators.CategoryValidators;

public class CreateCategoryValidator : AbstractValidator<CreateCategoryDto>
{
    public CreateCategoryValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Kategori adı boş bırakılamaz.")
            .MinimumLength(3).WithMessage("Kategori adı en az 3 karakter olmalıdır.")
            .MaximumLength(50).WithMessage("Kategori adı en fazla 50 karakter olabilir.");
    }
}
