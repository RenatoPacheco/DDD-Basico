namespace DddBasico.Auxiliares.Interfaces.Validacao
{
    public interface IValidacao<in Tipo>
        where Tipo : class
    {
        INotificarValidacao Validar(Tipo entidade);
    }
}
