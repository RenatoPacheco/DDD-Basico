using System;

namespace DddBasico.Dominio.Interfaces.Repositorios
{
    public interface IUnidadeDeTrabalho : IDisposable
    {
        void IniciarTransicao();

        void SalvarAlteracoes();

        void DesfazerAlteracoes();

        bool HaAlteracoes();
    }
}
