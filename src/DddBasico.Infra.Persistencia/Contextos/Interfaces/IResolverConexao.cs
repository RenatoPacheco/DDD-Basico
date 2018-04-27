namespace DddBasico.Infra.Persistencia.Contextos.Interfaces
{
    public interface IResolverConexao
    {
        string ObterReferencia();

        string ObterConexao();
    }
}
