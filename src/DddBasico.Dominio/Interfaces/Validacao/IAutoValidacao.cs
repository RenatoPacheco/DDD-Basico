namespace DddBasico.Dominio.Interfaces.Validacao
{
    public interface IAutoValidacao
    {
        INotificarValidacao Notificacoes { get; }

        bool EhValido();
    }
}
