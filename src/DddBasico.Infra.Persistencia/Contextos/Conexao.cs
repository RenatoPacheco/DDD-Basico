using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using DddBasico.Infra.Persistencia.Contextos.Interfaces;
using DddBasico.Infra.Persistencia.Contextos.Mapeamento;

namespace DddBasico.Infra.Persistencia.Contextos
{
    public class Conexao : IConexao
    {
        public Conexao()
        {
            DapperExtensions.DapperExtensions.SetMappingAssemblies(new[] { 
                typeof(UsuarioMap).Assembly 
            });
            this.Abrir();
        }

        public IDbConnection Sessao { get; private set; }

        public IDbTransaction Transicao { get; private set; }

        public void Dispose()
        {
            this.Fechar();
            GC.SuppressFinalize(this);
        }

        public IDbConnection Abrir()
        {
            return this.Abrir("DddBasico");
        }

        public IDbConnection Abrir(string referencia)
        {
            string connectionString = ConfigurationManager.ConnectionStrings[referencia].ConnectionString;
            this.Sessao = new SqlConnection(connectionString);
            this.Sessao.Open();
            return this.Sessao;
        }

        public void Fechar()
        {
            if (this.Sessao != null)
            {
                this.Sessao.Close();
                this.Sessao.Dispose();
            }
        }

        public bool HaSessao()
        {
            return !object.Equals(this.Sessao, null);
        }

        public bool HaTransicao()
        {
            return !object.Equals(this.Transicao, null);
        }

        public void IniciarTransicao()
        {
            this.Transicao = this.Sessao.BeginTransaction();
        }

        public void FecharTransicao()
        {
            this.Transicao.Commit();
        }

        public void DesfazerTransicao()
        {
            this.Transicao.Rollback();
        }
    }
}
