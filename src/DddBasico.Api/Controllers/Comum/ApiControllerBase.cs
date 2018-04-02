using DddBasico.Dominio.Interfaces.Validacao;
using DddBasico.Dominio.Validacao;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace DddBasico.Api.Controllers.Comum
{
    public class ApiControllerBase : ApiController
    {
        public ApiControllerBase()
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
                for(int e = 0; e < errosTotal; e++)
                {
                    resultado = false;
                    this.Notificacoes.Adicionar(erros[e].ErrorMessage.ToString(), referencia);
                }
            }
            
            return resultado;
        }


        public Task<HttpResponseMessage> CriarRespostaTask(HttpStatusCode codigo)
        {
            return this.CriarRespostaTask(codigo, null);
        }
        
        public Task<HttpResponseMessage> CriarRespostaTask(HttpStatusCode codigo, object @saida)
        {
            return Task.FromResult(this.CriarResposta(codigo, @saida));
        }

        public HttpResponseMessage CriarResposta(HttpStatusCode codigo)
        {
            return this.CriarResposta(codigo, null);
        }

        public HttpResponseMessage CriarResposta(HttpStatusCode codigo, object @saida)
        {
            HttpResponseMessage resultado = new HttpResponseMessage();

            if(!this.Validar(ModelState) || !this.Notificacoes.EhValido())
                codigo = HttpStatusCode.BadRequest;

            if ((int)codigo > 299)
            {
                resultado = Request.CreateResponse(codigo, new
                {
                    @Mensagem = "Ocorreu algum erro na requisição.",
                    @Notificacoes = this.Notificacoes.Mensagens
                });
            }
            else
            {
                if(object.Equals(saida, null))
                    resultado = Request.CreateResponse(codigo);
                else
                    resultado = Request.CreateResponse(codigo, saida);
            }

            return resultado;
        }
    }
}