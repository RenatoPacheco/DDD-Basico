using DddBasico.Dominio.Interfaces;
using DddBasico.Infra.Persistencia.Contextos;
using DddBasico.Infra.Persistencia.Contextos.Interfaces;
using SimpleInjector;

namespace DddBasico.Infra.CrossCutting.IdC.Modulos
{
    public static class InfraEstruturaModulo
    {
        public static void Carregar(Container recipiente)
        {
            recipiente.Register<IConexao>(() => new Conexao(), Lifestyle.Scoped);
            recipiente.Register<IUnidadeDeTrabalho, UnidadeDeTrabalho>(Lifestyle.Scoped);
        }
    }
}
