using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using DddBasico.Infra.Persistencia.Contextos.Interfaces;
using DddBasico.Infra.Persistencia.Contextos.Mapeamento;
using DddBasico.Dominio.Mensagens;

namespace DddBasico.Infra.Persistencia.Contextos
{
    public class Conexao : IConexao
    {
        public Conexao(IResolverConexao resolverConexao)
        {
            this._resolverConexao = resolverConexao;
        }
        
        private static bool _bancoMapeado;
        private readonly IResolverConexao _resolverConexao;

        private void MapearBanco()
        {
            _bancoMapeado = true;
            DapperExtensions.DapperExtensions.SetMappingAssemblies(new[] { 
                typeof(UsuarioMap).Assembly 
            });
        }

        private IDbConnection _sessao;
        public IDbConnection Sessao
        {
            get { return this._sessao ?? this.Abrir(); }
        }

        public IDbTransaction Transicao { get; private set; }

        public void Dispose()
        {
            this.Fechar();
            GC.SuppressFinalize(this);
        }
        
        public IDbConnection Abrir()
        {
            if (this._sessao != null)
                throw new Exception(SqlMsg.NaoHaSessaoAberta);
            
            if (!_bancoMapeado)
                this.MapearBanco();

            string connectionString = this._resolverConexao.ObterConexao();
            this._sessao = new SqlConnection(connectionString);
            this._sessao.Open();
            return this._sessao;
        }

        public void Fechar()
        {
            if (this._sessao != null)
            {
                if (this._sessao.State.Equals(ConnectionState.Open))
                    this._sessao.Close();

                this._sessao.Dispose();
            }
        }

        public bool HaSessao()
        {
            return !object.Equals(this._sessao, null);
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
