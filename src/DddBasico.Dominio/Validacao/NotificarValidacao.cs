using DddBasico.Dominio.Interfaces.Validacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DddBasico.Dominio.Validacao
{
    public class NotificarValidacao : INotificarValidacao
    {
        public NotificarValidacao()
        {
            this._mensagens = new List<IMensagemDeValidacao>();
        }

        private IList<IMensagemDeValidacao> _mensagens;

        public IMensagemDeValidacao[] Mensagens
        {
            get { return this._mensagens.ToArray(); }
        }

        public bool EhValido()
        {
            return this._mensagens.Count().Equals(0);
        }

        public IMensagemDeValidacao Adicionar(string mensagem)
        {
            IMensagemDeValidacao resultado = new MensagemDeValidacao(mensagem);
            this._mensagens.Add(resultado);
            return resultado;
        }

        public IMensagemDeValidacao Adicionar(string mensagem, string referencia)
        {
            IMensagemDeValidacao resultado = new MensagemDeValidacao(mensagem, referencia);
            this._mensagens.Add(resultado);
            return resultado;
        }

        public void Adicionar(IMensagemDeValidacao mensagem)
        {
            this._mensagens.Add(mensagem);
        }

        public void Adicionar(IAutoValidacao autoValidacao)
        {
            this._mensagens = this._mensagens
                .Concat(autoValidacao.Notificacoes.Mensagens).ToList();
        }

        public void Remover(IMensagemDeValidacao mensagem)
        {
            this._mensagens = this._mensagens.Where(
                x => !x.Equals(mensagem)).ToList();
        }

        public void Remover(Guid id)
        {
            this._mensagens = this._mensagens.Where(
                x => !x.Id.Equals(id)).ToList();
        }

        public void Remover(string referencia)
        {
            this._mensagens = this._mensagens.Where(
                x => !x.Referencia.Equals(referencia)).ToList();
        }

        public void Limpar()
        {
            this._mensagens.Clear();
        }
    }
}
