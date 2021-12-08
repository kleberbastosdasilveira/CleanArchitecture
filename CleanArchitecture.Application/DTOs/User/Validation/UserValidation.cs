using CleanArchitecture.Application.DTOs.User.DTO;
using CleanArchitecture.Domain.ResourceValidation;
using FluentValidation;

namespace CleanArchitecture.Application.DTOs.User.Validation
{
    public class UserValidation : AbstractValidator<UserDTO>
    {
        public UserValidation()
        {
            RuleFor(c => c.Name)
           .NotEmpty().WithMessage(Message.NomeInvalido)
           .Length(3, 100).WithMessage(Message.NomePequeno);

            RuleFor(c => c.Email)
            .EmailAddress().WithMessage("O campo {PropertyName} precisa ser preenchido corretamente");

            RuleFor(c => c.Password)
                .NotEmpty()
                .NotNull()
                .Equal(c => c.ConfirmPassword).WithMessage("O {PropertyName} não são identicos");
        }
    }
}
