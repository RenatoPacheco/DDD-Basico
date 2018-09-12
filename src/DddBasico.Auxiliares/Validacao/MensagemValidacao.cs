using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using DddBasico.Auxiliares.Interfaces.Validacao;

namespace DddBasico.Auxiliares.Validacao
{
    public class MensagemValidacao : IMensagemValidacao
    {
        private MensagemValidacao()
        {
            this.Id = Guid.NewGuid();
            this.Data = DateTime.Now;
        }

        public MensagemValidacao(string mensagem)
            : this(mensagem, TipoMensagem.Erro, null) { }

        public MensagemValidacao(
            string mensagem,
            string referencia)
            : this(mensagem, TipoMensagem.Erro, referencia) { }

        public MensagemValidacao(
            string mensagem,
            TipoMensagem tipo)
            : this(mensagem, tipo, null) { }

        public MensagemValidacao(
            string mensagem,
            TipoMensagem tipo, 
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

        public TipoMensagem Tipo { get; private set; }

        #region Operador -------------------------------------

        public override bool Equals(object obj)
        {
            MensagemValidacao comparar = obj as MensagemValidacao;
            return !object.Equals(comparar, null)
                && this.GetHashCode() == comparar.GetHashCode();
        }

        public override int GetHashCode()
        {
            return string.Format("[{0}:{1}]", this.Id, this.GetType()).GetHashCode();
        }

        public static bool operator ==(MensagemValidacao a, MensagemValidacao b)
        {
            return object.Equals(a, null) && object.Equals(b, null)
                || (!object.Equals(a, null) && !object.Equals(b, null) && a.Equals(b));
        }

        public static bool operator !=(MensagemValidacao a, MensagemValidacao b)
        {
            return !(object.Equals(a, null) && object.Equals(b, null)
                || (!object.Equals(a, null) && !object.Equals(b, null) && a.Equals(b)));
        }

        #endregion
    }
}
