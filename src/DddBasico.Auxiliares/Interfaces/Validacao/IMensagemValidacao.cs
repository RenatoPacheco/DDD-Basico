using System;
using DddBasico.Auxiliares.Validacao;

namespace DddBasico.Auxiliares.Interfaces.Validacao
{
    public interface IMensagemValidacao
    {
        Guid Id { get; }

        DateTime Data { get; }

        string Mensagem { get; }

        string Referencia { get; }

        TipoMensagem Tipo { get; }
    }
}
