using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Domain.ResourceValidation;
using FluentValidation;

namespace CleanArchitecture.Application.Validations
{
    public class CategoryValidation : AbstractValidator<CategoryDTO>
    {
        public CategoryValidation()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage(Message.NomeInvalido)
                .Length(3, 100).WithMessage(Message.NomePequeno);
        }
    }
}
