using DddBasico.Auxiliares.Interfaces.Validacao;
using DddBasico.Auxiliares.Mensagens;
using DddBasico.Auxiliares.Notacoes;
using DddBasico.Auxiliares.Validacao;
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DddBasico.Dominio.Comandos.Comum
{
    public abstract class GuidIdsCmd : IAutoValidacao
    {
        public GuidIdsCmd()
        {
            this.Ids = new List<Guid>();
            this._validacao = new Validacao<GuidIdsCmd>();
            this.Notificacoes = new NotificarValidacao();
        }

        public GuidIdsCmd(Guid id)
            : this()
        {
            this.Ids.Add(id);
        }

        public GuidIdsCmd(IEnumerable<Guid> ids)
            : this()
        {
            this.Ids = this.Ids.Concat(ids).ToList();
        }

        [Required(
            ErrorMessageResourceType = typeof(ValidacaoMsg),
            ErrorMessageResourceName = ValidacaoNomeMsg.EhRequerido)]
        [GuidValido(
            ErrorMessageResourceType = typeof(ValidacaoMsg),
            ErrorMessageResourceName = ValidacaoNomeMsg.NaoEhValido)]
        public virtual IList<Guid> Ids { get; set; }

        #region AutoValidacao

        private readonly IValidacao<GuidIdsCmd> _validacao;

        public INotificarValidacao Notificacoes { get; private set; }

        public bool EhValido()
        {
            this.Notificacoes = this._validacao.Validar(this);
            return this.Notificacoes.EhValido();
        }

        #endregion
    }
}
