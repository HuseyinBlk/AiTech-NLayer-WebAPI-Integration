using AiTech.DTO.ProjectDtos;
using FluentValidation;

namespace AiTech.Business.Validators.ProjectValidators;

public class UpdateProjectValidator : AbstractValidator<UpdateProjectDto>
{
    public UpdateProjectValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Geçersiz Proje ID'si.");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Proje başlığı boş bırakılamaz.")
            .MinimumLength(3).WithMessage("Proje başlığı en az 3 karakter olmalıdır.")
            .MaximumLength(100).WithMessage("Proje başlığı en fazla 100 karakter olabilir.");

        RuleFor(x => x.ImageUrl)
            .NotEmpty().WithMessage("Proje görseli boş bırakılamaz.")
            .MaximumLength(250).WithMessage("Görsel linki en fazla 250 karakter olabilir.");

        RuleFor(x => x.CategoryId)
            .GreaterThan(0).WithMessage("Lütfen geçerli bir kategori seçiniz.");
    }
}
