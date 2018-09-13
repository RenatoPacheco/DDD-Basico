using DddBasico.Auxiliares.Interfaces.Validacao;
using DddBasico.Auxiliares.Validacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DddBasico.Dominio.Comandos.UsuarioCmd
{
    public class FiltrarCmd : IAutoValidacao
    {
        public FiltrarCmd()
        {
            this._validacao = new Validacao<FiltrarCmd>();
            this.Notificacoes = new NotificarValidacao();
        }

        #region AutoValidacao

        private readonly IValidacao<FiltrarCmd> _validacao;

        public INotificarValidacao Notificacoes { get; private set; }

        public bool EhValido()
        {
            this.Notificacoes = this._validacao.Validar(this);
            return this.Notificacoes.EhValido();
        }

        #endregion
    }
}
