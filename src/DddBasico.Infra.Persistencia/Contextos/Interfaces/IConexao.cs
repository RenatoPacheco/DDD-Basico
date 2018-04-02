using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DddBasico.Infra.Persistencia.Contextos.Interfaces
{
    public interface IConexao : IDisposable
    {
        void Fechar();
        IDbConnection Abrir();
        bool HaSessao();
        bool HaTransicao();
        void IniciarTransicao();
        void FecharTransicao();
        void DesfazerTransicao();
        IDbConnection Sessao { get; }
        IDbTransaction Transicao { get; }
    }
}
