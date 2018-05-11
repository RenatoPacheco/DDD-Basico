namespace DddBasico.Auxiliares.Interfaces.Validacao
{
    public interface IAutoValidacao
    {
        INotificarValidacao Notificacoes { get; }

        bool EhValido();
    }
}
