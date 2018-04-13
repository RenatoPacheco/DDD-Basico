using System;
using System.Net;
using System.Web.Http;
using System.Net.Http;
using System.Threading.Tasks;
using DddBasico.Dominio.Entidades;
using DddBasico.Dominio.Comandos.UsuarioCmd;
using DddBasico.Dominio.Interfaces.Aplicacoes;
using DddBasico.Infra.Persistencia.Contextos.Interfaces;

namespace DddBasico.Api.Controllers
{
    [RoutePrefix("Usuario")]
    public class UsuarioController : Comum.ApiControllerBase
    {
        public UsuarioController(
            IUsuarioApp appUsuario)
            : base()
        {
            this._appUsuario = appUsuario;
        }

        private readonly IUsuarioApp _appUsuario;

        [HttpGet, Route]
        public Task<HttpResponseMessage> Get()
        {
            Usuario[] resultado = new Usuario[] { };

            resultado = this._appUsuario.Listar();
            this.Validar(this._appUsuario);

            return CriarRespostaTask(HttpStatusCode.OK, resultado);
        }

        [HttpGet, Route("{id}")]
        public Task<HttpResponseMessage> Get([FromUri]ObterCmd parametros)
        {
            InvocarSeNulo<ObterCmd>(ref parametros);
            Usuario resultado = null;

            if (this.EhValido())
            {
                resultado = this._appUsuario.Obter(parametros);
                this.Validar(this._appUsuario);
            }

            return CriarRespostaTask(HttpStatusCode.OK, resultado);
        }

        [HttpPost, Route]
        public Task<HttpResponseMessage> Post([FromBody]InserirCmd parametros)
        {
            InvocarSeNulo<InserirCmd>(ref parametros);
            Usuario resultado = null;

            if (this.EhValido())
            {
                resultado = this._appUsuario.Inserir(parametros);
                this.Validar(this._appUsuario);
            }

            return CriarRespostaTask(HttpStatusCode.OK, new {
                Id = object.Equals(resultado, null) ? null : (Guid?)resultado.Id
            });
        }

        [HttpPut, Route("{id}")]
        public Task<HttpResponseMessage> Put([FromUri]Guid? id, [FromBody]AtualizarCmd parametros)
        {
            InvocarSeNulo<AtualizarCmd>(ref parametros);
            parametros.Id = id;
            Usuario resultado = null;

            if (this.EhValido())
            {
                resultado = this._appUsuario.Atualizar(parametros);
                this.Validar(this._appUsuario);
            }

            return CriarRespostaTask(HttpStatusCode.OK);
        }

        [HttpPatch, Route("{id}")]
        public Task<HttpResponseMessage> Patch([FromUri]Guid? id, [FromBody]AtualizarCmd parametros)
        {
            InvocarSeNulo<AtualizarCmd>(ref parametros);
            parametros.Id = id;
            Usuario resultado = null;

            if (this.EhValido())
            {
                resultado = this._appUsuario.Atualizar(parametros);
                this.Validar(this._appUsuario);
            }

            return CriarRespostaTask(HttpStatusCode.OK);
        }

        [HttpDelete, Route("{id}")]
        public Task<HttpResponseMessage> Delete([FromUri]DeletarCmd parametros)
        {
            InvocarSeNulo<DeletarCmd>(ref parametros);
            Usuario resultado = null;

            if (this.EhValido())
            {
                resultado = this._appUsuario.Deletar(parametros);
                this.Validar(this._appUsuario);
            }

            return CriarRespostaTask(HttpStatusCode.OK);
        }
    }
}
