using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DddBasico.Dominio.Interfaces
{
    public interface IUnidadeDeTrabalho : IDisposable
    {
        void IniciarTransicao();

        void SalvarAlteracoes();

        void DesfazerAlteracoes();

        bool HaTransicao();
    }
}
