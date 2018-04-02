using System;
namespace DddBasico.Dominio.Interfaces.Validacao
{
    public interface INotificarValidacao
    {
        IMensagemDeValidacao[] Mensagens { get; }

        bool EhValido();

        IMensagemDeValidacao Adicionar(string mensagem);

        IMensagemDeValidacao Adicionar(string mensagem, string referencia);

        void Adicionar(IMensagemDeValidacao mensagem);

        void Adicionar(IAutoValidacao autoValidacao);

        void Remover(IMensagemDeValidacao mensagem);

        void Remover(Guid id);

        void Remover(string referencia);

        void Limpar();

    }
}
