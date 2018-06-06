using DddBasico.Dominio.Entidades;
using DddBasico.Auxiliares.Interfaces.Validacao;
using DddBasico.Auxiliares.Notacoes;
using DddBasico.Auxiliares.Validacao;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DddBasico.Auxiliares.Mensagens;

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

        [Requerido(
            ErrorMessageResourceType = typeof(ValidacaoMsg),
            ErrorMessageResourceName = ValidacaoNomeMsg.EhRequerido)]
        [GuidValido(
            ErrorMessageResourceType = typeof(ValidacaoMsg),
            ErrorMessageResourceName = ValidacaoNomeMsg.NaoEhValido)]
        public virtual Guid? Id { get; set; }

        [Requerido(true,
            ErrorMessageResourceType = typeof(ValidacaoMsg),
            ErrorMessageResourceName = ValidacaoNomeMsg.NaoPodeSerVazio)]
        [MaxLength(50,
            ErrorMessageResourceType = typeof(ValidacaoMsg),
            ErrorMessageResourceName = ValidacaoNomeMsg.MaximoDeCaracteres)]
        public virtual string Nome { get; set; }

        [Requerido(true,
            ErrorMessageResourceType = typeof(ValidacaoMsg),
            ErrorMessageResourceName = ValidacaoNomeMsg.NaoPodeSerVazio)]
        [MaxLength(100,
            ErrorMessageResourceType = typeof(ValidacaoMsg),
            ErrorMessageResourceName = ValidacaoNomeMsg.MaximoDeCaracteres)]
        public virtual string Sobrenome { get; set; }

        [Display(Name = "E-mail")]
        [EmailAddress(
            ErrorMessageResourceType = typeof(ValidacaoMsg),
            ErrorMessageResourceName = ValidacaoNomeMsg.NaoEhValido)]
        [MaxLength(100,
            ErrorMessageResourceType = typeof(ValidacaoMsg),
            ErrorMessageResourceName = ValidacaoNomeMsg.MaximoDeCaracteres)]
        public virtual string Email { get; set; }

        [Display(Name = "Confirma e-mail")]
        [Compare("Email",
            ErrorMessageResourceType = typeof(ValidacaoMsg),
            ErrorMessageResourceName = ValidacaoNomeMsg.DevemSerIguais)]
        public virtual string ConfirmaEmail { get; set; }

        [Requerido(true,
            ErrorMessageResourceType = typeof(ValidacaoMsg),
            ErrorMessageResourceName = ValidacaoNomeMsg.NaoPodeSerVazio)]
        [MinLength(8,
            ErrorMessageResourceType = typeof(ValidacaoMsg),
            ErrorMessageResourceName = ValidacaoNomeMsg.MinimoDeCaracteres)]
        [MaxLength(30,
            ErrorMessageResourceType = typeof(ValidacaoMsg),
            ErrorMessageResourceName = ValidacaoNomeMsg.MaximoDeCaracteres)]
        public virtual string Senha { get; set; }

        [Display(Name = "Confirma senha")]
        [Compare("Senha",
            ErrorMessageResourceType = typeof(ValidacaoMsg),
            ErrorMessageResourceName = ValidacaoNomeMsg.DevemSerIguais)]
        public virtual string ConfirmaSenha { get; set; }

        public virtual void Aplicar(ref Usuario dados)
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

        public virtual void Desfazer(ref Usuario dados)
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
