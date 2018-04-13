using DddBasico.Dominio.Interfaces;
using DddBasico.Infra.Persistencia.Contextos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DddBasico.Infra.Persistencia.Contextos
{
    public class UnidadeDeTrabalho
        : IUnidadeDeTrabalho, IDisposable
    {
        public UnidadeDeTrabalho(IConexao connexao)
        {
            this._connexao = connexao;
        }

        private readonly IConexao _connexao;

        public void Dispose()
        {
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

        public bool HaTransicao()
        {
            return this._connexao.HaTransicao();
        }
    }
}
