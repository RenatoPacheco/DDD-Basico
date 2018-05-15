using DddBasico.Auxiliares.Validacao;
using System;
using System.Linq.Expressions;
namespace DddBasico.Auxiliares.Interfaces.Validacao
{
    public interface INotificarValidacao
    {
        IMensagemDeValidacao[] Mensagens { get; }

        bool EhValido();
        
        #region Adicionar

        IMensagemDeValidacao Adicionar(string mensagem);

        IMensagemDeValidacao Adicionar(string mensagem, string referencia);

        IMensagemDeValidacao Adicionar(string mensagem, TipoDeMensagem tipo);

        IMensagemDeValidacao Adicionar(string mensagem, TipoDeMensagem tipo, string referencia);

        IMensagemDeValidacao Adicionar<TClasse>(Expression<Func<TClasse, object>> expressao, string mensagem);

        IMensagemDeValidacao Adicionar<TClasse>(Expression<Func<TClasse, object>> expressao, string mensagem, string referencia);

        IMensagemDeValidacao Adicionar<TClasse>(Expression<Func<TClasse, object>> expressao, string mensagem, TipoDeMensagem tipo);

        IMensagemDeValidacao Adicionar<TClasse>(Expression<Func<TClasse, object>> expressao, string mensagem, TipoDeMensagem tipo, string referencia);
        
        void Adicionar(IMensagemDeValidacao mensagem);

        void Adicionar(IAutoValidacao autoValidacao);

        #endregion

        #region Erro

        IMensagemDeValidacao Erro(string mensagem);

        IMensagemDeValidacao Erro(string mensagem, string referencia);

        IMensagemDeValidacao Erro<TClasse>(Expression<Func<TClasse, object>> expressao);

        IMensagemDeValidacao Erro<TClasse>(Expression<Func<TClasse, object>> expressao, string mensagem);

        IMensagemDeValidacao Erro<TClasse>(Expression<Func<TClasse, object>> expressao, string mensagem, string referencia);

        #endregion

        #region Sucesso

        IMensagemDeValidacao Sucesso(string mensagem);

        IMensagemDeValidacao Sucesso(string mensagem, string referencia);

        IMensagemDeValidacao Sucesso<TClasse>(Expression<Func<TClasse, object>> expressao);

        IMensagemDeValidacao Sucesso<TClasse>(Expression<Func<TClasse, object>> expressao, string mensagem);

        IMensagemDeValidacao Sucesso<TClasse>(Expression<Func<TClasse, object>> expressao, string mensagem, string referencia);

        #endregion

        #region Atencao

        IMensagemDeValidacao Atencao(string mensagem);

        IMensagemDeValidacao Atencao(string mensagem, string referencia);

        IMensagemDeValidacao Atencao<TClasse>(Expression<Func<TClasse, object>> expressao);

        IMensagemDeValidacao Atencao<TClasse>(Expression<Func<TClasse, object>> expressao, string mensagem);

        IMensagemDeValidacao Atencao<TClasse>(Expression<Func<TClasse, object>> expressao, string mensagem, string referencia);

        #endregion

        void Remover(IMensagemDeValidacao mensagem);

        void Remover(Guid id);

        void Remover(string referencia);

        void Limpar();

        void Limpar(params TipoDeMensagem[] tipos);
    }
}
