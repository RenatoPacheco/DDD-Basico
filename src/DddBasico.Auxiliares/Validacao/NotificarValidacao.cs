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
            this._mensagens = new List<IMensagemValidacao>();
        }

        private IList<IMensagemValidacao> _mensagens;
        
        public IMensagemValidacao[] Mensagens
        {
            get { return (new List<IMensagemValidacao>()).Concat(this._mensagens).ToArray(); }
        }

        public bool EhValido()
        {
            return !this.HaMensagens(TipoMensagem.Erro);
        }

        private bool HaMensagens(params TipoMensagem[] tipos)
        {
            return this._mensagens.Where(x => tipos.Contains(x.Tipo)).Take(1).Count().Equals(1);
        }

        private IMensagemValidacao[] ObterMensagens(params TipoMensagem[] tipos)
        {
            return this._mensagens.Where(x => tipos.Contains(x.Tipo)).ToArray();
        }

        #region Adicionar

        public IMensagemValidacao Adicionar(string mensagem)
        {
            IMensagemValidacao resultado = new MensagemValidacao(mensagem);
            this._mensagens.Add(resultado);
            return resultado;
        }

        public IMensagemValidacao Adicionar(string mensagem, string referencia)
        {
            IMensagemValidacao resultado = new MensagemValidacao(mensagem, referencia);
            this._mensagens.Add(resultado);
            return resultado;
        }

        public IMensagemValidacao Adicionar(string mensagem, TipoMensagem tipo)
        {
            IMensagemValidacao resultado = new MensagemValidacao(mensagem, tipo);
            this._mensagens.Add(resultado);
            return resultado;
        }

        public IMensagemValidacao Adicionar(string mensagem, TipoMensagem tipo, string referencia)
        {
            IMensagemValidacao resultado = new MensagemValidacao(mensagem, tipo, referencia);
            this._mensagens.Add(resultado);
            return resultado;
        }

        public void Adicionar(IMensagemValidacao mensagem)
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
            IMensagemValidacao[] mensagens = notificacao.Mensagens;
            int total = mensagens.Count();
            for (int i = 0; i < total; i++)
                this._mensagens.Add(mensagens[i]);
        }

        public IMensagemValidacao Adicionar<TClasse>(Expression<Func<TClasse, object>> expressao, string mensagem)
        {
            mensagem = Regex.Replace(mensagem, @"\{0\}", expressao.PropNome());
            string referencia = expressao.PropExtensoComTrilha();
            return this.Adicionar(mensagem, referencia);
        }

        public IMensagemValidacao Adicionar<TClasse>(Expression<Func<TClasse, object>> expressao, string mensagem, string referencia)
        {
            mensagem = Regex.Replace(mensagem, @"\{0\}", expressao.PropNome());
            return this.Adicionar(mensagem, referencia);
        }

        public IMensagemValidacao Adicionar<TClasse>(Expression<Func<TClasse, object>> expressao, string mensagem, TipoMensagem tipo)
        {
            mensagem = Regex.Replace(mensagem, @"\{0\}", expressao.PropNome());
            string referencia = expressao.PropExtensoComTrilha();
            return this.Adicionar(mensagem, tipo, referencia);
        }

        public IMensagemValidacao Adicionar<TClasse>(Expression<Func<TClasse, object>> expressao, string mensagem, TipoMensagem tipo, string referencia)
        {
            mensagem = Regex.Replace(mensagem, @"\{0\}", expressao.PropNome());
            return this.Adicionar(mensagem, tipo, referencia);
        }

        #endregion

        #region Erro

        public void LimparErro()
        {
            this.Limpar(TipoMensagem.Erro);
        }

        public IMensagemValidacao[] ObterErro()
        {
            return this.ObterMensagens(TipoMensagem.Erro);
        }

        public IMensagemValidacao Erro(string mensagem)
        {
            return this.Adicionar(mensagem, TipoMensagem.Erro);
        }

        public IMensagemValidacao Erro(string mensagem, string referencia)
        {
            return this.Adicionar(mensagem, TipoMensagem.Erro, referencia);
        }

        public IMensagemValidacao Erro<TClasse>(Expression<Func<TClasse, object>> expressao)
        {
            return this.Adicionar(expressao, "{0} não é válido(a)", TipoMensagem.Erro);
        }

        public IMensagemValidacao Erro<TClasse>(Expression<Func<TClasse, object>> expressao, string mensagem)
        {
            return this.Adicionar(expressao, mensagem, TipoMensagem.Erro);
        }

        public IMensagemValidacao Erro<TClasse>(Expression<Func<TClasse, object>> expressao, string mensagem, string referencia)
        {
            return this.Adicionar(expressao, mensagem, TipoMensagem.Erro, referencia);
        }

        #endregion

        #region Sucesso

        public void LimparSucesso()
        {
            this.Limpar(TipoMensagem.Sucesso);
        }

        public IMensagemValidacao[] ObterSucesso()
        {
            return this.ObterMensagens(TipoMensagem.Sucesso);
        }

        public IMensagemValidacao Sucesso(string mensagem)
        {
            return this.Adicionar(mensagem, TipoMensagem.Sucesso);
        }

        public IMensagemValidacao Sucesso(string mensagem, string referencia)
        {
            return this.Adicionar(mensagem, TipoMensagem.Sucesso, referencia);
        }

        public IMensagemValidacao Sucesso<TClasse>(Expression<Func<TClasse, object>> expressao)
        {
            return this.Adicionar(expressao, "{0} é válido(a)", TipoMensagem.Sucesso);
        }

        public IMensagemValidacao Sucesso<TClasse>(Expression<Func<TClasse, object>> expressao, string mensagem)
        {
            return this.Adicionar(expressao, mensagem, TipoMensagem.Sucesso);
        }

        public IMensagemValidacao Sucesso<TClasse>(Expression<Func<TClasse, object>> expressao, string mensagem, string referencia)
        {
            return this.Adicionar(expressao, mensagem, TipoMensagem.Sucesso, referencia);
        }

        #endregion

        #region Atencao

        public void LimparAtencao()
        {
            this.Limpar(TipoMensagem.Atencao);
        }

        public IMensagemValidacao[] ObterAtencao()
        {
            return this.ObterMensagens(TipoMensagem.Atencao);
        }

        public IMensagemValidacao Atencao(string mensagem)
        {
            return this.Adicionar(mensagem, TipoMensagem.Atencao);
        }

        public IMensagemValidacao Atencao(string mensagem, string referencia)
        {
            return this.Adicionar(mensagem, TipoMensagem.Atencao, referencia);
        }

        public IMensagemValidacao Atencao<TClasse>(Expression<Func<TClasse, object>> expressao)
        {
            return this.Adicionar(expressao, "{0} teve problemas, mas é válido(a)", TipoMensagem.Atencao);
        }

        public IMensagemValidacao Atencao<TClasse>(Expression<Func<TClasse, object>> expressao, string mensagem)
        {
            return this.Adicionar(expressao, mensagem, TipoMensagem.Atencao);
        }

        public IMensagemValidacao Atencao<TClasse>(Expression<Func<TClasse, object>> expressao, string mensagem, string referencia)
        {
            return this.Adicionar(expressao, mensagem, TipoMensagem.Atencao, referencia);
        }

        #endregion

        #region Remover

        public void Remover(IMensagemValidacao mensagem)
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

        private void Limpar(params TipoMensagem[] tipos)
        {
            this._mensagens = this._mensagens.Where(
                x => !tipos.Contains(x.Tipo)).ToList();
        }

        #endregion
    }
}
