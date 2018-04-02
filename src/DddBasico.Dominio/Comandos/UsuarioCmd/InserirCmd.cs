using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using DddBasico.Dominio.Entidades;
using DddBasico.Dominio.Mensagens;
using DddBasico.Dominio.Notacoes;
using DddBasico.Dominio.Validacao;
using System.ComponentModel.DataAnnotations;
using DddBasico.Dominio.Interfaces.Validacao;

namespace DddBasico.Dominio.Comandos.UsuarioCmd
{
    public class InserirCmd : IAutoValidacao
    {
        public InserirCmd()
        {
            this._validacao = new Validacao<InserirCmd>();
            this.Notificacoes = new NotificarValidacao();
        }

        [Required(
            ErrorMessageResourceType = typeof(ValidacoesMsg),
            ErrorMessageResourceName = "EhObrigatorio")]
        [NaoPodeSerVazio(
            ErrorMessageResourceType = typeof(ValidacoesMsg),
            ErrorMessageResourceName = "NaoPodeSerVazio")]
        [MaxLength(50,
            ErrorMessageResourceType = typeof(ValidacoesMsg),
            ErrorMessageResourceName = "MaximoDeCaracteres")]
        public string Nome { get; set; }

        [Required(
            ErrorMessageResourceType = typeof(ValidacoesMsg),
            ErrorMessageResourceName = "EhObrigatorio")]
        [NaoPodeSerVazio(
            ErrorMessageResourceType = typeof(ValidacoesMsg),
            ErrorMessageResourceName = "NaoPodeSerVazio")]
        [MaxLength(100,
            ErrorMessageResourceType = typeof(ValidacoesMsg),
            ErrorMessageResourceName = "MaximoDeCaracteres")]
        public string Sobrenome { get; set; }

        [Display(Name = "E-mail")]
        [Required(
            ErrorMessageResourceType = typeof(ValidacoesMsg),
            ErrorMessageResourceName = "EhObrigatorio")]
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

        [Required(
            ErrorMessageResourceType = typeof(ValidacoesMsg),
            ErrorMessageResourceName = "EhObrigatorio")]
        [NaoPodeSerVazio(
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
            dados = new Usuario(this.Nome, this.Sobrenome, this.Email, this.Senha);
        }

        public void Desfazer(ref Usuario dados)
        {
            dados = null;
        }

        #region AutoValidacao

        private readonly IValidacao<InserirCmd> _validacao;

        public INotificarValidacao Notificacoes { get; private set; }

        public bool EhValido()
        {
            this.Notificacoes = this._validacao.Validar(this);
            return this.Notificacoes.EhValido();
        }

        #endregion
    }
}
