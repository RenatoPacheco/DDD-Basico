using System;
using DddBasico.Auxiliares.Validacao;

namespace DddBasico.Auxiliares.Interfaces.Validacao
{
    public interface IMensagemDeValidacao
    {
        Guid Id { get; }

        DateTime Data { get; }

        string Mensagem { get; }

        string Referencia { get; }

        TipoDeMensagem Tipo { get; }
    }
}
