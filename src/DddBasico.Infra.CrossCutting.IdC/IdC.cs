using SimpleInjector;

namespace DddBasico.Infra.CrossCutting.IdC
{
    public static class IdC
    {
        public static void Carregar(Container recipiente)
        {
            Modulos.InfraEstruturaModulo.Carregar(recipiente);
            Modulos.AplicacaoModulo.Carregar(recipiente);
            Modulos.RepositorioModulo.Carregar(recipiente);
            Modulos.ServicoModulo.Carregar(recipiente);
        }
    }
}
