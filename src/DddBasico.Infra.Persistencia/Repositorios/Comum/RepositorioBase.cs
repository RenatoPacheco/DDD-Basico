using DddBasico.Auxiliares.Interfaces.Validacao;
using DddBasico.Auxiliares.Validacao;
using DddBasico.Infra.Persistencia.Contextos.Interfaces;
using DddBasico.Infra.Persistencia.Contextos.Mapeamento;

namespace DddBasico.Infra.Persistencia.Repositorios.Comum
{
    public abstract class RepositorioBase : IAutoValidacao
    {
        public RepositorioBase(IConexao conexao)
        {
            this._conexao = conexao;
            this.Notificacoes = new NotificarValidacao();
        }

        protected readonly IConexao _conexao;

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
    }
}
