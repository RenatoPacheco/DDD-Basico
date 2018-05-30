using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using DddBasico.Auxiliares.Extensoes;
using System.Text.RegularExpressions;
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

        private bool HaMensagens(params TipoDeMensagem[] tipos)
        {
            return this._mensagens.Where(x => tipos.Contains(x.Tipo)).Take(1).Count().Equals(1);
        }

        private IMensagemDeValidacao[] ObterMensagens(params TipoDeMensagem[] tipos)
        {
            return this._mensagens.Where(x => tipos.Contains(x.Tipo)).ToArray();
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

        public void Adicionar(INotificarValidacao notificacao)
        {
            IMensagemDeValidacao[] mensagens = notificacao.Mensagens;
            int total = mensagens.Count();
            for (int i = 0; i < total; i++)
                this._mensagens.Add(mensagens[i]);
        }

        public IMensagemDeValidacao Adicionar<TClasse>(Expression<Func<TClasse, object>> expressao, string mensagem)
        {
            mensagem = Regex.Replace(mensagem, @"\{0\}", expressao.PropNome());
            string referencia = expressao.PropExtensoComTrilha();
            return this.Adicionar(mensagem, referencia);
        }

        public IMensagemDeValidacao Adicionar<TClasse>(Expression<Func<TClasse, object>> expressao, string mensagem, string referencia)
        {
            mensagem = Regex.Replace(mensagem, @"\{0\}", expressao.PropNome());
            return this.Adicionar(mensagem, referencia);
        }

        public IMensagemDeValidacao Adicionar<TClasse>(Expression<Func<TClasse, object>> expressao, string mensagem, TipoDeMensagem tipo)
        {
            mensagem = Regex.Replace(mensagem, @"\{0\}", expressao.PropNome());
            string referencia = expressao.PropExtensoComTrilha();
            return this.Adicionar(mensagem, tipo, referencia);
        }

        public IMensagemDeValidacao Adicionar<TClasse>(Expression<Func<TClasse, object>> expressao, string mensagem, TipoDeMensagem tipo, string referencia)
        {
            mensagem = Regex.Replace(mensagem, @"\{0\}", expressao.PropNome());
            return this.Adicionar(mensagem, tipo, referencia);
        }

        #endregion

        #region Erro

        public void LimparErro()
        {
            this.Limpar(TipoDeMensagem.Erro);
        }

        public IMensagemDeValidacao[] ObterErro()
        {
            return this.ObterMensagens(TipoDeMensagem.Erro);
        }

        public IMensagemDeValidacao Erro(string mensagem)
        {
            return this.Adicionar(mensagem, TipoDeMensagem.Erro);
        }

        public IMensagemDeValidacao Erro(string mensagem, string referencia)
        {
            return this.Adicionar(mensagem, TipoDeMensagem.Erro, referencia);
        }

        public IMensagemDeValidacao Erro<TClasse>(Expression<Func<TClasse, object>> expressao)
        {
            return this.Adicionar(expressao, "{0} não é válido(a)", TipoDeMensagem.Erro);
        }

        public IMensagemDeValidacao Erro<TClasse>(Expression<Func<TClasse, object>> expressao, string mensagem)
        {
            return this.Adicionar(expressao, mensagem, TipoDeMensagem.Erro);
        }

        public IMensagemDeValidacao Erro<TClasse>(Expression<Func<TClasse, object>> expressao, string mensagem, string referencia)
        {
            return this.Adicionar(expressao, mensagem, TipoDeMensagem.Erro, referencia);
        }

        #endregion

        #region Sucesso

        public void LimparSucesso()
        {
            this.Limpar(TipoDeMensagem.Sucesso);
        }

        public IMensagemDeValidacao[] ObterSucesso()
        {
            return this.ObterMensagens(TipoDeMensagem.Sucesso);
        }

        public IMensagemDeValidacao Sucesso(string mensagem)
        {
            return this.Adicionar(mensagem, TipoDeMensagem.Sucesso);
        }

        public IMensagemDeValidacao Sucesso(string mensagem, string referencia)
        {
            return this.Adicionar(mensagem, TipoDeMensagem.Sucesso, referencia);
        }

        public IMensagemDeValidacao Sucesso<TClasse>(Expression<Func<TClasse, object>> expressao)
        {
            return this.Adicionar(expressao, "{0} é válido(a)", TipoDeMensagem.Sucesso);
        }

        public IMensagemDeValidacao Sucesso<TClasse>(Expression<Func<TClasse, object>> expressao, string mensagem)
        {
            return this.Adicionar(expressao, mensagem, TipoDeMensagem.Sucesso);
        }

        public IMensagemDeValidacao Sucesso<TClasse>(Expression<Func<TClasse, object>> expressao, string mensagem, string referencia)
        {
            return this.Adicionar(expressao, mensagem, TipoDeMensagem.Sucesso, referencia);
        }

        #endregion

        #region Atencao

        public void LimparAtencao()
        {
            this.Limpar(TipoDeMensagem.Atencao);
        }

        public IMensagemDeValidacao[] ObterAtencao()
        {
            return this.ObterMensagens(TipoDeMensagem.Atencao);
        }

        public IMensagemDeValidacao Atencao(string mensagem)
        {
            return this.Adicionar(mensagem, TipoDeMensagem.Atencao);
        }

        public IMensagemDeValidacao Atencao(string mensagem, string referencia)
        {
            return this.Adicionar(mensagem, TipoDeMensagem.Atencao, referencia);
        }

        public IMensagemDeValidacao Atencao<TClasse>(Expression<Func<TClasse, object>> expressao)
        {
            return this.Adicionar(expressao, "{0} teve problemas, mas é válido(a)", TipoDeMensagem.Atencao);
        }

        public IMensagemDeValidacao Atencao<TClasse>(Expression<Func<TClasse, object>> expressao, string mensagem)
        {
            return this.Adicionar(expressao, mensagem, TipoDeMensagem.Atencao);
        }

        public IMensagemDeValidacao Atencao<TClasse>(Expression<Func<TClasse, object>> expressao, string mensagem, string referencia)
        {
            return this.Adicionar(expressao, mensagem, TipoDeMensagem.Atencao, referencia);
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

        private void Limpar(params TipoDeMensagem[] tipos)
        {
            this._mensagens = this._mensagens.Where(
                x => !tipos.Contains(x.Tipo)).ToList();
        }

        #endregion
    }
}
