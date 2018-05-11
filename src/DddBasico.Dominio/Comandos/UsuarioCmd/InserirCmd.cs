using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using DddBasico.Dominio.Entidades;
using DddBasico.Auxiliares.Notacoes;
using DddBasico.Auxiliares.Validacao;
using System.ComponentModel.DataAnnotations;
using DddBasico.Auxiliares.Interfaces.Validacao;
using DddBasico.Auxiliares.Mensagens;

namespace DddBasico.Dominio.Comandos.UsuarioCmd
{
    public class InserirCmd : IAutoValidacao
    {
        public InserirCmd()
        {
            this._validacao = new Validacao<InserirCmd>();
            this.Notificacoes = new NotificarValidacao();
        }

        [Requerido(
            ErrorMessageResourceType = typeof(ValidacaoMsg),
            ErrorMessageResourceName = "EhRequerido")]
        [MaxLength(50,
            ErrorMessageResourceType = typeof(ValidacaoMsg),
            ErrorMessageResourceName = "MaximoDeCaracteres")]
        public virtual string Nome { get; set; }

        [Requerido(
            ErrorMessageResourceType = typeof(ValidacaoMsg),
            ErrorMessageResourceName = "EhRequerido")]
        [MaxLength(100,
            ErrorMessageResourceType = typeof(ValidacaoMsg),
            ErrorMessageResourceName = "MaximoDeCaracteres")]
        public virtual string Sobrenome { get; set; }

        [Display(Name = "E-mail")]
        
        [Requerido(
            ErrorMessageResourceType = typeof(ValidacaoMsg),
            ErrorMessageResourceName = "EhRequerido")]
        [EmailAddress(
            ErrorMessageResourceType = typeof(ValidacaoMsg),
            ErrorMessageResourceName = "NaoEhValido")]
        [MaxLength(100,
            ErrorMessageResourceType = typeof(ValidacaoMsg),
            ErrorMessageResourceName = "MaximoDeCaracteres")]
        public virtual string Email { get; set; }

        [Display(Name = "Confirma e-mail")]
        [Compare("Email",
            ErrorMessageResourceType = typeof(ValidacaoMsg),
            ErrorMessageResourceName = "DevemSerIguais")]
        public virtual string ConfirmaEmail { get; set; }

        [Requerido(
            ErrorMessageResourceType = typeof(ValidacaoMsg),
            ErrorMessageResourceName = "EhRequerido")]
        [MinLength(8,
            ErrorMessageResourceType = typeof(ValidacaoMsg),
            ErrorMessageResourceName = "MinimoDeCaracteres")]
        [MaxLength(30,
            ErrorMessageResourceType = typeof(ValidacaoMsg),
            ErrorMessageResourceName = "MaximoDeCaracteres")]
        public virtual string Senha { get; set; }

        [Display(Name = "Confirma senha")]
        [Compare("Senha",
            ErrorMessageResourceType = typeof(ValidacaoMsg),
            ErrorMessageResourceName = "DevemSerIguais")]
        public virtual string ConfirmaSenha { get; set; }

        public virtual void Aplicar(ref Usuario dados)
        {
            dados = new Usuario(this.Nome, this.Sobrenome, this.Email, this.Senha);
        }

        public virtual void Desfazer(ref Usuario dados)
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
