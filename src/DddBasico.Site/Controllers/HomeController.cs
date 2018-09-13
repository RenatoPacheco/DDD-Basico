using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DddBasico.Site.Controllers
{
    public class HomeController : Comum.ControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}