using System;
using DddBasico.Dominio.Interfaces;
using DddBasico.Dominio.Interfaces.Repositorios;
using DddBasico.Infra.Persistencia.Contextos.Interfaces;

namespace DddBasico.Infra.Persistencia.Contextos
{
    public class UnidadeDeTrabalho
        : IUnidadeDeTrabalho
    {
        public UnidadeDeTrabalho(IConexao connexao)
        {
            this._connexao = connexao;
        }

        private readonly IConexao _connexao;

        public void Dispose()
        {
            if (this._connexao.HaSessao())
                if (this._connexao.HaTransicao())
                    this.SalvarAlteracoes();

            GC.SuppressFinalize(this);
        }

        public void IniciarTransicao()
        {
            this._connexao.IniciarTransicao();
        }

        public void SalvarAlteracoes()
        {
            this._connexao.FecharTransicao();
        }

        public void DesfazerAlteracoes()
        {
            this._connexao.DesfazerTransicao();
        }

        public bool HaAlteracoes()
        {
            return this._connexao.HaTransicao();
        }
    }
}
