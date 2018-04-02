using DddBasico.Dominio.Interfaces.Validacao;
using DddBasico.Dominio.Validacao;

namespace DddBasico.Dominio.Servicos.Comum
{
    public abstract class ServicoBase : IAutoValidacao
    {
        public ServicoBase()
        {
            this.Notificacoes = new NotificarValidacao();
        }

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
