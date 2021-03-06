﻿using DddBasico.Auxiliares.Interfaces.Validacao;
using DddBasico.Auxiliares.Mensagens;
using DddBasico.Auxiliares.Notacoes;
using DddBasico.Auxiliares.Validacao;
using System;
using System.ComponentModel.DataAnnotations;

namespace DddBasico.Dominio.Comandos.Comum
{
    public abstract class GuidIdCmd : IAutoValidacao
    {
        public GuidIdCmd()
        {
            this._validacao = new Validacao<GuidIdCmd>();
            this.Notificacoes = new NotificarValidacao();
        }

        public GuidIdCmd(Guid? id)
            : this()
        {
            this.Id = id;
        }

        [Required(
            ErrorMessageResourceType = typeof(ValidacaoMsg),
            ErrorMessageResourceName = ValidacaoNomeMsg.EhRequerido)]
        [GuidValido(
            ErrorMessageResourceType = typeof(ValidacaoMsg),
            ErrorMessageResourceName = ValidacaoNomeMsg.NaoEhValido)]
        public virtual Guid? Id { get; set; }

        #region AutoValidacao

        private readonly IValidacao<GuidIdCmd> _validacao;

        public INotificarValidacao Notificacoes { get; private set; }

        public bool EhValido()
        {
            this.Notificacoes = this._validacao.Validar(this);
            return this.Notificacoes.EhValido();
        }

        #endregion
    }
}
