using SimpleInjector;

namespace DddBasico.Infra.IdC
{
    public static class Injetar
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
