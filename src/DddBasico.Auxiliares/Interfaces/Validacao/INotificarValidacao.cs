using System;
using System.Linq.Expressions;
using DddBasico.Auxiliares.Validacao;

namespace DddBasico.Auxiliares.Interfaces.Validacao
{
    public interface INotificarValidacao
    {
        IMensagemValidacao[] Mensagens { get; }

        bool EhValido();
        
        #region Adicionar

        IMensagemValidacao Adicionar(string mensagem);

        IMensagemValidacao Adicionar(string mensagem, string referencia);

        IMensagemValidacao Adicionar(string mensagem, TipoMensagem tipo);

        IMensagemValidacao Adicionar(string mensagem, TipoMensagem tipo, string referencia);

        IMensagemValidacao Adicionar<TClasse>(Expression<Func<TClasse, object>> expressao, string mensagem);

        IMensagemValidacao Adicionar<TClasse>(Expression<Func<TClasse, object>> expressao, string mensagem, string referencia);

        IMensagemValidacao Adicionar<TClasse>(Expression<Func<TClasse, object>> expressao, string mensagem, TipoMensagem tipo);

        IMensagemValidacao Adicionar<TClasse>(Expression<Func<TClasse, object>> expressao, string mensagem, TipoMensagem tipo, string referencia);
        
        void Adicionar(IMensagemValidacao mensagem);

        void Adicionar(IAutoValidacao autoValidacao);

        void Adicionar(INotificarValidacao notificacao);

        #endregion

        #region Erro

        IMensagemValidacao Erro(string mensagem);

        IMensagemValidacao Erro(string mensagem, string referencia);

        IMensagemValidacao Erro<TClasse>(Expression<Func<TClasse, object>> expressao);

        IMensagemValidacao Erro<TClasse>(Expression<Func<TClasse, object>> expressao, string mensagem);

        IMensagemValidacao Erro<TClasse>(Expression<Func<TClasse, object>> expressao, string mensagem, string referencia);

        IMensagemValidacao[] ObterErro();

        void LimparErro();

        #endregion

        #region Sucesso

        IMensagemValidacao Sucesso(string mensagem);

        IMensagemValidacao Sucesso(string mensagem, string referencia);

        IMensagemValidacao Sucesso<TClasse>(Expression<Func<TClasse, object>> expressao);

        IMensagemValidacao Sucesso<TClasse>(Expression<Func<TClasse, object>> expressao, string mensagem);

        IMensagemValidacao Sucesso<TClasse>(Expression<Func<TClasse, object>> expressao, string mensagem, string referencia);

        IMensagemValidacao[] ObterSucesso();

        void LimparSucesso();

        #endregion

        #region Atencao

        IMensagemValidacao Atencao(string mensagem);

        IMensagemValidacao Atencao(string mensagem, string referencia);

        IMensagemValidacao Atencao<TClasse>(Expression<Func<TClasse, object>> expressao);

        IMensagemValidacao Atencao<TClasse>(Expression<Func<TClasse, object>> expressao, string mensagem);

        IMensagemValidacao Atencao<TClasse>(Expression<Func<TClasse, object>> expressao, string mensagem, string referencia);

        IMensagemValidacao[] ObterAtencao();

        void LimparAtencao();

        #endregion

        void Remover(IMensagemValidacao mensagem);

        void Remover(Guid id);

        void Remover(string referencia);

        void Limpar();
    }
}
