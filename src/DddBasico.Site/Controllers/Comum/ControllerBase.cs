using DddBasico.Auxiliares.Interfaces.Validacao;
using DddBasico.Auxiliares.Validacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace DddBasico.Site.Controllers.Comum
{
    public class ControllerBase : Controller
    {
        public ControllerBase()
        {
            this.Notificacoes = new NotificarValidacao();
        }

        public readonly INotificarValidacao Notificacoes;

        public bool InvocarSeNuloEValidar<TClasse>(ref TClasse classe)
            where TClasse : IAutoValidacao
        {
            if (object.Equals(classe, null))
            {
                var constructor = typeof(TClasse).GetConstructor(Type.EmptyTypes);
                classe = (TClasse)constructor.Invoke(null);
                this.Validar(classe);
            }

            return ModelState.IsValid;
        }

        public static bool InvocarSeNulo<TClasse>(ref TClasse classe)
            where TClasse : class
        {
            if (object.Equals(classe, null))
            {
                var constructor = typeof(TClasse).GetConstructor(Type.EmptyTypes);
                classe = (TClasse)constructor.Invoke(null);
                return true;
            }
            return false;
        }

        public bool EhValido()
        {
            return this.Notificacoes.EhValido()
                && ModelState.IsValid;
        }

        public void LimparValidacao()
        {
            this.Notificacoes.Limpar();
            this.ModelState.Clear();
        }

        public bool Validar(IAutoValidacao dados)
        {
            bool retorno = dados.EhValido();
            this.Notificacoes.Adicionar(dados);
            return retorno;
        }

        public bool Validar(ModelStateDictionary dados)
        {
            string chave, referencia;
            ModelErrorCollection erros;
            int errosTotal;
            int chavesTotal = dados.Keys.Count();
            bool resultado = true;

            for (int c = 0; c < chavesTotal; c++)
            {
                chave = dados.Keys.ElementAt(c);
                erros = dados[chave].Errors;
                referencia = Regex.Replace(chave, @"^[^\.]+\.", "");
                errosTotal = erros.Count();
                for (int e = 0; e < errosTotal; e++)
                {
                    resultado = false;
                    this.Notificacoes.Adicionar(erros[e].ErrorMessage.ToString(), referencia);
                }
            }

            return resultado;
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            this.Validar(this.ModelState);
            base.OnActionExecuting(filterContext);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            this.ModelState.Clear();
            foreach (IMensagemValidacao erro in this.Notificacoes.ObterErro())
            {
                this.ModelState.AddModelError(erro.Referencia, erro.Mensagem);
            }
            base.OnActionExecuted(filterContext);
        }
    }
}