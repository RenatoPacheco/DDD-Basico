using DddBasico.Dominio.Interfaces.Servicos;
using DddBasico.Dominio.Servicos;
using SimpleInjector;

namespace DddBasico.Infra.CrossCutting.IdC.Modulos
{
    public static class ServicoModulo
    {
        public static void Carregar(Container recipiente)
        {
            recipiente.Register<IUsuarioServ, UsuarioServ>();
        }
    }
}
