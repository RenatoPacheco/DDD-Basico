using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DddBasico.Dominio.Interfaces.Validacao
{
    public interface IMensagemDeValidacao
    {
        Guid Id { get; }

        DateTime Data { get; }

        string Mensagem { get; }

        string Referencia { get; }
    }
}
