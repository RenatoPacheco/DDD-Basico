using DddBasico.Dominio.Interfaces.Aplicacoes;
using DddBasico.Aplicacao;
using SimpleInjector;

namespace DddBasico.Infra.IdC.Modulos
{
    public static class AplicacaoModulo
    {
        public static void Carregar(Container recipiente)
        {
            recipiente.Register<IUsuarioApp, UsuarioApp>();
        }
    }
}
