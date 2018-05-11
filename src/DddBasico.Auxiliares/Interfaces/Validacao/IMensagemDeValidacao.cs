using DddBasico.Auxiliares.Validacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
