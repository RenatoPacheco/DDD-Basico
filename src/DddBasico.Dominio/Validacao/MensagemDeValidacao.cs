using DddBasico.Dominio.Interfaces.Validacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DddBasico.Dominio.Validacao
{
    public class MensagemDeValidacao : IMensagemDeValidacao
    {
        private MensagemDeValidacao()
        {
            this.Id = Guid.NewGuid();
            this.Data = DateTime.Now;
        }

        public MensagemDeValidacao(string mensagem)
            : this(mensagem, null) { }

        public MensagemDeValidacao(
            string mensagem, 
            string referencia)
            : this()
        {
            this.Mensagem = mensagem;
            this.Referencia = referencia;
        }

        public Guid Id { get; private set; }

        public DateTime Data { get; private set; }

        public string Mensagem { get; private set; }

        public string Referencia { get; private set; }

        #region Operador -------------------------------------

        public override bool Equals(object obj)
        {
            MensagemDeValidacao comparar = obj as MensagemDeValidacao;
            return !object.Equals(comparar, null)
                && this.GetHashCode() == comparar.GetHashCode();
        }

        public override int GetHashCode()
        {
            return string.Format("[{0}:{1}]", this.Id, typeof(MensagemDeValidacao)).GetHashCode();
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
