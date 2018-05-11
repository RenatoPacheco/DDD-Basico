using DddBasico.Auxiliares.Validacao;
using System;
using System.Linq.Expressions;
namespace DddBasico.Auxiliares.Interfaces.Validacao
{
    public interface INotificarValidacao
    {
        IMensagemDeValidacao[] Mensagens { get; }

        bool EhValido();

        bool EhValido(params TipoDeMensagem[] tipos);

        IMensagemDeValidacao Adicionar(string mensagem);

        IMensagemDeValidacao Adicionar(string mensagem, string referencia);

        IMensagemDeValidacao Adicionar(string mensagem, TipoDeMensagem tipo);

        IMensagemDeValidacao Adicionar(string mensagem, TipoDeMensagem tipo, string referencia);

        IMensagemDeValidacao Adicionar<TClasse>(string mensagem, Expression<Func<TClasse, object>> referencia);

        IMensagemDeValidacao Adicionar<TClasse>(string mensagem, TipoDeMensagem tipo, Expression<Func<TClasse, object>> referencia);
        
        void Adicionar(IMensagemDeValidacao mensagem);

        void Adicionar(IAutoValidacao autoValidacao);

        void Remover(IMensagemDeValidacao mensagem);

        void Remover(Guid id);

        void Remover(string referencia);

        void Limpar();

        void Limpar(params TipoDeMensagem[] tipos);
    }
}
