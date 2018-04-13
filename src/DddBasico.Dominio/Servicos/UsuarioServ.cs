using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using DddBasico.Dominio.Entidades;
using DddBasico.Dominio.Comandos.Comum;
using DddBasico.Dominio.Interfaces.Servicos;
using DddBasico.Dominio.Comandos.UsuarioCmd;
using DddBasico.Dominio.Interfaces.Repositorios;

namespace DddBasico.Dominio.Servicos
{
    public class UsuarioServ : Comum.ServicoBase, IUsuarioServ
    {
        public UsuarioServ(
            IUsuarioRep repUsuario)
            : base()
        {
            this._repUsuario = repUsuario;
        }

        private readonly IUsuarioRep _repUsuario;

        public Usuario Inserir(InserirCmd comando)
        {
            this.Notificacoes.Limpar();
            Usuario resultado = null;

            if(this.Validar(comando))
            {
                comando.Aplicar(ref resultado);
                this._repUsuario.Inserir(resultado);
                if (!this.Validar(this._repUsuario))
                    resultado = null;
            }

            return resultado;
        }

        public Usuario Atualizar(AtualizarCmd comando)
        {
            this.Notificacoes.Limpar();
            Usuario resultado = null;

            if (this.Validar(comando))
            {
                resultado = this.Obter(new ObterCmd(comando.Id));
                if(this.EhValido())
                {
                    comando.Aplicar(ref resultado);
                    this._repUsuario.Atualizar(resultado);
                    if (!this.Validar(this._repUsuario))
                        resultado = null;
                }
            }

            return resultado;
        }
        
        public Usuario Obter(ObterCmd comando)
        {
            this.Notificacoes.Limpar();
            Usuario resultado = null;

            if(this.Validar(comando))
            {
                resultado = this._repUsuario.Obter(comando.Id.Value);
                if (!this.Validar(this._repUsuario))
                    resultado = null;
            }

            return resultado;
        }

        public Usuario[] Listar()
        {
            this.Notificacoes.Limpar();
            Usuario[] resultado = null;

            resultado = this._repUsuario.Listar();
            if (!this.Validar(this._repUsuario))
                resultado = new Usuario[] { };

            return resultado;
        }

        public Usuario Deletar(DeletarCmd comando)
        {
            this.Notificacoes.Limpar();
            Usuario resultado = null;

            if (this.Validar(comando))
            {
                resultado = this.Obter(new ObterCmd(comando.Id));
                if (this.EhValido())
                {
                    this._repUsuario.Deletar(resultado);
                    if (!this.Validar(this._repUsuario))
                        resultado = null;
                }
            }

            return resultado;
        }
    }
}
