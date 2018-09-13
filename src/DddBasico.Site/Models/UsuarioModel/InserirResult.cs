using DddBasico.Dominio.Comandos.UsuarioCmd;
using DddBasico.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DddBasico.Site.Models.UsuarioModel
{
    public class InserirResult
    {
        public InserirResult(InserirCmd parametros)
        {
            this.Parametros = parametros;
        }

        public InserirCmd Parametros { get; set; }

        public Usuario Resultado { get; set; }
    }
}