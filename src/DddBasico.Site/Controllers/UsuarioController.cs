using DddBasico.Dominio.Comandos.UsuarioCmd;
using DddBasico.Dominio.Entidades;
using DddBasico.Dominio.Interfaces.Aplicacoes;
using DddBasico.Site.Models.UsuarioModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DddBasico.Site.Controllers
{
    public class UsuarioController : Comum.ControllerBase
    {
        public UsuarioController(
            IUsuarioApp appUsuario)
            : base()
        {
            this._appUsuario = appUsuario;
        }

        private readonly IUsuarioApp _appUsuario;
        
        [HttpGet]
        [ActionName("Index")]
        public ActionResult IndexGet(FiltrarCmd parametros)
        {
            FiltrarResult result = new FiltrarResult(parametros);
            if (this.EhValido())
            {
                result.Resultados = this._appUsuario.Filtrar(parametros);
                this.Validar(this._appUsuario);
            }
            return View(result);
        }

        [HttpGet]
        [ActionName("Inserir")]
        public ActionResult InserirGet()
        {
            InserirCmd parametros = new InserirCmd();
            InserirResult result = new InserirResult(parametros);
            return View(result);
        }

        [HttpPost]
        [ActionName("Inserir")]
        public ActionResult InserirPost(InserirCmd parametros)
        {
            InserirResult result = new InserirResult(parametros);
            if (this.EhValido())
            {
                result.Resultado = this._appUsuario.Inserir(parametros);
                this.Validar(this._appUsuario);
            }
            return View(result);
        }
    }
}