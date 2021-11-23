using CleanArchitecture.Application.Notificacoes;
using System.Collections.Generic;

namespace CleanArchitecture.Application.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
