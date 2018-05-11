using System;
using DapperExtensions;
using DddBasico.Infra.Persistencia.Contextos.Interfaces;
using DddBasico.Dominio.Interfaces.Repositorios.Comum;
using DddBasico.Infra.Persistencia.Mensagens;

namespace DddBasico.Infra.Persistencia.Repositorios.Comum
{
    public abstract class Repositorio<Entidade, Identificador> : RepositorioBase, 
        IRepositorio<Entidade, Identificador>
        where Entidade : class
    {
        public Repositorio(IConexao conexao)
            : base(conexao) { }

        public void Inserir(Entidade entidade)
        {
            object resultado = this._conexao.Sessao.Insert(entidade, this._conexao.Transicao);

            if (object.Equals(resultado, null))
                this.Notificacoes.Adicionar(SqlMsg.NaoInserido);
        }

        public void Atualizar(Entidade entidade)
        {
            bool resultado = this._conexao.Sessao.Update(entidade, this._conexao.Transicao);

            if (!resultado)
                this.Notificacoes.Adicionar(SqlMsg.NaoAtualizado);
        }
        public void Deletar(Entidade entidade)
        {
            bool resultado = this._conexao.Sessao.Delete(entidade, this._conexao.Transicao);

            if (!resultado)
                this.Notificacoes.Adicionar(SqlMsg.NaoDeletado);
        }
        public Entidade Obter(Identificador id)
        {
            Entidade resultado = this._conexao.Sessao.Get<Entidade>(id, this._conexao.Transicao);

            if (object.Equals(resultado, null))
                this.Notificacoes.Adicionar(SqlMsg.NaoEncontrado);

            return resultado;
        }

        public abstract Entidade[] Listar();
    }
}
