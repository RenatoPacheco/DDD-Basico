using DddBasico.Dominio.Interfaces.Aplicacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DddBasico.Site.Controllers
{
    public class UsuarioController : Controller
    {
        public UsuarioController(
            IUsuarioApp appUsuario)
            : base()
        {
            this._appUsuario = appUsuario;
        }

        private readonly IUsuarioApp _appUsuario;

        public ActionResult Index()
        {
            return View();
        }
    }
}