﻿using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using DddBasico.Auxiliares.Interfaces.Validacao;

namespace DddBasico.Auxiliares.Validacao
{
    public class MensagemDeValidacao : IMensagemDeValidacao
    {
        private MensagemDeValidacao()
        {
            this.Id = Guid.NewGuid();
            this.Data = DateTime.Now;
        }

        public MensagemDeValidacao(string mensagem)
            : this(mensagem, TipoDeMensagem.Erro, null) { }

        public MensagemDeValidacao(
            string mensagem,
            string referencia)
            : this(mensagem, TipoDeMensagem.Erro, referencia) { }

        public MensagemDeValidacao(
            string mensagem,
            TipoDeMensagem tipo)
            : this(mensagem, tipo, null) { }

        public MensagemDeValidacao(
            string mensagem,
            TipoDeMensagem tipo, 
            string referencia)
            : this()
        {
            this.Mensagem = mensagem;
            this.Referencia = referencia;
            this.Tipo = tipo;
        }

        public Guid Id { get; private set; }

        public DateTime Data { get; private set; }

        public string Mensagem { get; private set; }

        public string Referencia { get; private set; }

        public TipoDeMensagem Tipo { get; private set; }

        #region Operador -------------------------------------

        public override bool Equals(object obj)
        {
            MensagemDeValidacao comparar = obj as MensagemDeValidacao;
            return !object.Equals(comparar, null)
                && this.GetHashCode() == comparar.GetHashCode();
        }

        public override int GetHashCode()
        {
            return string.Format("[{0}:{1}]", this.Id, this.GetType()).GetHashCode();
        }

        public static bool operator ==(MensagemDeValidacao a, MensagemDeValidacao b)
        {
            return object.Equals(a, null) && object.Equals(b, null)
                || (!object.Equals(a, null) && !object.Equals(b, null) && a.Equals(b));
        }

        public static bool operator !=(MensagemDeValidacao a, MensagemDeValidacao b)
        {
            return !(object.Equals(a, null) && object.Equals(b, null)
                || (!object.Equals(a, null) && !object.Equals(b, null) && a.Equals(b)));
        }

        #endregion
    }
}
