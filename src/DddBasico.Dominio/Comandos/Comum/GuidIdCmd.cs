﻿using DddBasico.Dominio.Interfaces.Validacao;
using DddBasico.Dominio.Mensagens;
using DddBasico.Dominio.Notacoes;
using DddBasico.Dominio.Validacao;
using System;
using System.ComponentModel.DataAnnotations;

namespace DddBasico.Dominio.Comandos.Comum
{
    public class GuidIdCmd : IAutoValidacao
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
            ErrorMessageResourceType = typeof(ValidacoesMsg),
            ErrorMessageResourceName = "EhObrigatorio")]
        [GuidValido(
            ErrorMessageResourceType = typeof(ValidacoesMsg),
            ErrorMessageResourceName = "NaoEhValido")]
        public Guid? Id { get; set; }

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
