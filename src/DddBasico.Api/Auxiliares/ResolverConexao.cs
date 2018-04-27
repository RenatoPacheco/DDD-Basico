using DddBasico.Infra.Persistencia.Contextos.Interfaces;
using System.Configuration;

namespace DddBasico.Api.Auxiliares
{
    public class ResolverConexao : IResolverConexao 
    {
        public string ObterReferencia()
        {
            return "DddBasico";
        }

        public string ObterConexao()
        {
            return ConfigurationManager.ConnectionStrings[this.ObterReferencia()].ConnectionString;
        }
    }
}