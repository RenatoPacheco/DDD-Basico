using DddBasico.Dominio.Interfaces.Repositorios;
using DddBasico.Infra.Persistencia.Repositorios;
using SimpleInjector;

namespace DddBasico.Infra.IdC.Modulos
{
    public static class RepositorioModulo
    {
        public static void Carregar(Container recipiente)
        {
            recipiente.Register<IUsuarioRep, UsuarioRep>();
        }
    }
}
