using System;
using DddBasico.Dominio.Entidades;
using DddBasico.Dominio.Interfaces;
using DddBasico.Dominio.Interfaces.Servicos;
using DddBasico.Dominio.Comandos.UsuarioCmd;
using DddBasico.Dominio.Interfaces.Aplicacoes;

namespace DddBasico.Aplicacao
{
    public class UsuarioApp : Comum.ApliccaoBase, IUsuarioApp
    {
        public UsuarioApp(
            IUnidadeDeTrabalho udt,
            IUsuarioServ servUsuario)
            : base(udt)
        {
            this._servUsuario = servUsuario;
        }

        private readonly IUsuarioServ _servUsuario;

        public Usuario Inserir(InserirCmd comando)
        {
            this.Notificacoes.Limpar();
            Usuario resultado = null;

            this.IniciarTransicao();
            resultado = this._servUsuario.Inserir(comando);
            this.Validar(this._servUsuario);
            this.EncerrarTransicao();

            return resultado;
        }

        public Usuario Atualizar(AtualizarCmd comando)
        {
            this.Notificacoes.Limpar();
            Usuario resultado = null;

            this.IniciarTransicao();
            resultado = this._servUsuario.Atualizar(comando);
            this.Validar(this._servUsuario);
            this.EncerrarTransicao();

            return resultado;
        }

        public Usuario Obter(ObterCmd comando)
        {
            this.Notificacoes.Limpar();
            Usuario resultado = null;

            this.IniciarTransicao();
            resultado = this._servUsuario.Obter(comando);
            this.Validar(this._servUsuario);
            this.EncerrarTransicao();

            return resultado;
        }

        public Usuario[] Listar()
        {
            this.Notificacoes.Limpar();
            Usuario[] resultado = new Usuario[] { };

            this.IniciarTransicao();
            resultado = this._servUsuario.Listar();
            this.Validar(this._servUsuario);
            this.EncerrarTransicao();

            return resultado;
        }

        public Usuario Deletar(DeletarCmd comando)
        {
            this.Notificacoes.Limpar();
            Usuario resultado = null;

            this.IniciarTransicao();
            resultado = this._servUsuario.Deletar(comando);
            this.Validar(this._servUsuario);
            this.EncerrarTransicao();

            return resultado;
        }
    }
}
