using Dapper;
using System;
using System.Linq;
using DddBasico.Dominio.Entidades;
using DddBasico.Infra.Persistencia.Mensagens;
using DddBasico.Dominio.Interfaces.Repositorios;
using DddBasico.Infra.Persistencia.Contextos.Interfaces;

namespace DddBasico.Infra.Persistencia.Repositorios
{
    public class UsuarioRep : Comum.Repositorio<Usuario, Guid>,
        IUsuarioRep
    {
        public UsuarioRep(IConexao conexao)
            : base(conexao) { }
                
        public override Usuario[] Listar()
        {
            this.Notificacoes.Limpar();
            Usuario[] resultado = this._conexao.Sessao.Query<Usuario>(@"
                    SELECT TOP 1000 * 
                    FROM Usuario AS usu",
                transaction: this._conexao.Transicao).ToArray();
            
            if (resultado.Equals(0))
                this.Notificacoes.Adicionar(SqlMsg.NaoEncontrado);

            return resultado;
        }
    }
}
