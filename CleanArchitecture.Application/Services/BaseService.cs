using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Notificacoes;
using FluentValidation;
using FluentValidation.Results;

namespace CleanArchitecture.Application.Services
{
    public abstract class BaseServices
    {
        private readonly INotificador _notificador;
        public BaseServices(INotificador notificador)
        {
            _notificador = notificador;
        }
        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }

        protected bool ExecultarValidacao<TV, TE>(TV validacao, TE entidate) where TV : AbstractValidator<TE> where TE : class
        {
            var validation = validacao.Validate(entidate);

            if (validation.IsValid) return true;

            Notificar(validation); return false;
        }
    }
}
