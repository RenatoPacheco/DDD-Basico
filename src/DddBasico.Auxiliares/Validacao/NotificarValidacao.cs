using DddBasico.Auxiliares.Interfaces.Validacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DddBasico.Auxiliares.Extensoes;

namespace DddBasico.Auxiliares.Validacao
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
            return this.EhValido(TipoDeMensagem.Erro);
        }

        public bool EhValido(params TipoDeMensagem[] tipos)
        {
            return this._mensagens.Where(x => tipos.Contains(x.Tipo)).Take(1).Count().Equals(0);
        }

        #region Adicionar

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

        public IMensagemDeValidacao Adicionar(string mensagem, TipoDeMensagem tipo)
        {
            IMensagemDeValidacao resultado = new MensagemDeValidacao(mensagem, tipo);
            this._mensagens.Add(resultado);
            return resultado;
        }

        public IMensagemDeValidacao Adicionar(string mensagem, TipoDeMensagem tipo, string referencia)
        {
            IMensagemDeValidacao resultado = new MensagemDeValidacao(mensagem, tipo, referencia);
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

        public IMensagemDeValidacao Adicionar<TClasse>(string mensagem, Expression<Func<TClasse, object>> referencia)
        {
            return this.Adicionar(mensagem, referencia.PropExtensoComTrilha());
        }

        public IMensagemDeValidacao Adicionar<TClasse>(string mensagem, TipoDeMensagem tipo, Expression<Func<TClasse, object>> referencia)
        {
            return this.Adicionar(mensagem, tipo, referencia.PropExtensoComTrilha());
        }

        #endregion

        #region Remover

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

        #endregion

        public void Limpar()
        {
            this._mensagens.Clear();
        }

        public void Limpar(params TipoDeMensagem[] tipos)
        {
            this._mensagens = this._mensagens.Where(
                x => !tipos.Contains(x.Tipo)).ToList();
        }        
    }
}
