using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using DddBasico.Auxiliares.Extensoes;
using DddBasico.Auxiliares.Interfaces.Validacao;

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
            get { return (new List<IMensagemDeValidacao>()).Concat(this._mensagens).ToArray(); }
        }

        public bool EhValido()
        {
            return !this.HaMensagens(TipoDeMensagem.Erro);
        }

        public bool HaMensagens(params TipoDeMensagem[] tipos)
        {
            return this._mensagens.Where(x => tipos.Contains(x.Tipo)).Take(1).Count().Equals(1);
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

        public IMensagemDeValidacao Adicionar<TClasse>(Expression<Func<TClasse, object>> referencia, string mensagem)
        {
            return this.Adicionar(mensagem, referencia.PropExtensoComTrilha());
        }

        public IMensagemDeValidacao Adicionar<TClasse>(Expression<Func<TClasse, object>> referencia, string mensagem, TipoDeMensagem tipo)
        {
            return this.Adicionar(mensagem, tipo, referencia.PropExtensoComTrilha());
        }

        #endregion

        #region Erro

        public IMensagemDeValidacao Erro(string mensagem)
        {
            IMensagemDeValidacao resultado = new MensagemDeValidacao(mensagem);
            this._mensagens.Add(resultado);
            return resultado;
        }

        public IMensagemDeValidacao Erro(string mensagem, string referencia)
        {
            IMensagemDeValidacao resultado = new MensagemDeValidacao(mensagem, referencia);
            this._mensagens.Add(resultado);
            return resultado;
        }

        public IMensagemDeValidacao Erro<TClasse>(Expression<Func<TClasse, object>> referencia)
        {
            return this.Adicionar("{0} não é válido", referencia.PropExtensoComTrilha());
        }

        public IMensagemDeValidacao Erro<TClasse>(Expression<Func<TClasse, object>> referencia, string mensagem)
        {
            return this.Adicionar(mensagem, referencia.PropExtensoComTrilha());
        }

        #endregion

        #region Sucesso

        public IMensagemDeValidacao Sucesso(string mensagem)
        {
            IMensagemDeValidacao resultado = new MensagemDeValidacao(mensagem, TipoDeMensagem.Sucesso);
            this._mensagens.Add(resultado);
            return resultado;
        }

        public IMensagemDeValidacao Sucesso(string mensagem, string referencia)
        {
            IMensagemDeValidacao resultado = new MensagemDeValidacao(mensagem, TipoDeMensagem.Sucesso, referencia);
            this._mensagens.Add(resultado);
            return resultado;
        }

        public IMensagemDeValidacao Sucesso<TClasse>(Expression<Func<TClasse, object>> referencia)
        {
            return this.Adicionar("{0} é válido", TipoDeMensagem.Sucesso, referencia.PropExtensoComTrilha());
        }

        public IMensagemDeValidacao Sucesso<TClasse>(Expression<Func<TClasse, object>> referencia, string mensagem)
        {
            return this.Adicionar(mensagem, TipoDeMensagem.Sucesso, referencia.PropExtensoComTrilha());
        }

        #endregion

        #region Atencao

        public IMensagemDeValidacao Atencao(string mensagem)
        {
            IMensagemDeValidacao resultado = new MensagemDeValidacao(mensagem, TipoDeMensagem.Atencao);
            this._mensagens.Add(resultado);
            return resultado;
        }

        public IMensagemDeValidacao Atencao(string mensagem, string referencia)
        {
            IMensagemDeValidacao resultado = new MensagemDeValidacao(mensagem, TipoDeMensagem.Atencao, referencia);
            this._mensagens.Add(resultado);
            return resultado;
        }

        public IMensagemDeValidacao Atencao<TClasse>(Expression<Func<TClasse, object>> referencia)
        {
            return this.Adicionar("{0} teve problemas, mas é válido", TipoDeMensagem.Atencao, referencia.PropExtensoComTrilha());
        }

        public IMensagemDeValidacao Atencao<TClasse>(Expression<Func<TClasse, object>> referencia, string mensagem)
        {
            return this.Adicionar(mensagem, TipoDeMensagem.Atencao, referencia.PropExtensoComTrilha());
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

        #region Limpar

        public void Limpar()
        {
            this._mensagens.Clear();
        }

        public void Limpar(params TipoDeMensagem[] tipos)
        {
            this._mensagens = this._mensagens.Where(
                x => !tipos.Contains(x.Tipo)).ToList();
        }

        #endregion
    }
}
