using DddBasico.Dominio.Entidades;
using DddBasico.Auxiliares.Interfaces.Validacao;
using DddBasico.Dominio.Mensagens;
using DddBasico.Auxiliares.Notacoes;
using DddBasico.Auxiliares.Validacao;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DddBasico.Dominio.Comandos.UsuarioCmd
{
    public class AtualizarCmd : IAutoValidacao
    {
        public AtualizarCmd()
        {
            this._validacao = new Validacao<AtualizarCmd>();
            this.Notificacoes = new NotificarValidacao();
        }

        public AtualizarCmd(Usuario dados)
            : this()
        {
            this.Id = dados.Id;
            this.Nome = dados.Nome;
            this.Sobrenome = dados.Sobrenome;
        }

        [EhRequerido(
            ErrorMessageResourceType = typeof(ValidacoesMsg),
            ErrorMessageResourceName = "EhObrigatorio")]
        [GuidValido(
            ErrorMessageResourceType = typeof(ValidacoesMsg),
            ErrorMessageResourceName = "NaoEhValido")]
        public Guid? Id { get; set; }

        [EhRequerido(true,
            ErrorMessageResourceType = typeof(ValidacoesMsg),
            ErrorMessageResourceName = "NaoPodeSerVazio")]
        [MaxLength(50,
            ErrorMessageResourceType = typeof(ValidacoesMsg),
            ErrorMessageResourceName = "MaximoDeCaracteres")]
        public string Nome { get; set; }

        [EhRequerido(true,
            ErrorMessageResourceType = typeof(ValidacoesMsg),
            ErrorMessageResourceName = "NaoPodeSerVazio")]
        [MaxLength(100,
            ErrorMessageResourceType = typeof(ValidacoesMsg),
            ErrorMessageResourceName = "MaximoDeCaracteres")]
        public string Sobrenome { get; set; }

        [Display(Name = "E-mail")]
        [EmailAddress(
            ErrorMessageResourceType = typeof(ValidacoesMsg),
            ErrorMessageResourceName = "NaoEhValido")]
        [MaxLength(100,
            ErrorMessageResourceType = typeof(ValidacoesMsg),
            ErrorMessageResourceName = "MaximoDeCaracteres")]
        public string Email { get; set; }

        [Display(Name = "Confirma e-mail")]
        [Compare("Email",
            ErrorMessageResourceType = typeof(ValidacoesMsg),
            ErrorMessageResourceName = "DevemSerIguais")]
        public string ConfirmaEmail { get; set; }

        [EhRequerido(true,
            ErrorMessageResourceType = typeof(ValidacoesMsg),
            ErrorMessageResourceName = "NaoPodeSerVazio")]
        [MinLength(8,
            ErrorMessageResourceType = typeof(ValidacoesMsg),
            ErrorMessageResourceName = "MinimoDeCaracteres")]
        [MaxLength(30,
            ErrorMessageResourceType = typeof(ValidacoesMsg),
            ErrorMessageResourceName = "MaximoDeCaracteres")]
        public string Senha { get; set; }

        [Display(Name = "Confirma senha")]
        [Compare("Senha",
            ErrorMessageResourceType = typeof(ValidacoesMsg),
            ErrorMessageResourceName = "DevemSerIguais")]
        public string ConfirmaSenha { get; set; }

        public void Aplicar(ref Usuario dados)
        {
            if (!object.Equals(this.Nome, null))
                dados.Nome = this.Nome;

            if (!object.Equals(this.Sobrenome, null))
                dados.Sobrenome = this.Sobrenome;

            if (!object.Equals(this.Email, null))
                dados.Email = this.Email;

            if (!object.Equals(this.Senha, null))
                dados.Senha = this.Senha;
        }

        public void Desfazer(ref Usuario dados)
        {
            dados = null;
        }

        #region AutoValidacao

        private readonly IValidacao<AtualizarCmd> _validacao;

        public INotificarValidacao Notificacoes { get; private set; }

        public bool EhValido()
        {
            this.Notificacoes = this._validacao.Validar(this);
            return this.Notificacoes.EhValido();
        }

        #endregion
    }
}
