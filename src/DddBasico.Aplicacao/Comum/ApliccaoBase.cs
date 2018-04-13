using DddBasico.Dominio.Interfaces;
using DddBasico.Dominio.Validacao;
using DddBasico.Dominio.Interfaces.Validacao;

namespace DddBasico.Aplicacao.Comum
{
    public abstract class ApliccaoBase : IAutoValidacao
    {
        public ApliccaoBase(
            IUnidadeDeTrabalho udt)
        {
            this._udt = udt;
            this.Notificacoes = new NotificarValidacao();
        }

        private readonly IUnidadeDeTrabalho _udt;

        #region AutoValidacao

        public INotificarValidacao Notificacoes { get; private set; }

        public bool EhValido()
        {
            return this.Notificacoes.EhValido();
        }

        protected bool Validar(IAutoValidacao dados)
        {
            bool resultado = dados.EhValido();
            this.Notificacoes.Adicionar(dados);
            return resultado;
        }

        #endregion

        public void IniciarTransicao()
        {
            this._udt.IniciarTransicao();
        }

        public void EncerrarTransicao()
        {
            if (this.EhValido())
                this.SalvarAlteracoes();
            else
                this.DesfazerAlteracoes();
        }

        public void SalvarAlteracoes()
        {
            this._udt.SalvarAlteracoes();
        }

        public void DesfazerAlteracoes()
        {
            this._udt.DesfazerAlteracoes();
        }
    }
}
