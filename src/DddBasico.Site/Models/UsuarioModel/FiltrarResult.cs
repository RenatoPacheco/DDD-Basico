using DddBasico.Dominio.Comandos.UsuarioCmd;
using DddBasico.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DddBasico.Site.Models.UsuarioModel
{
    public class FiltrarResult
    {
        public FiltrarResult(FiltrarCmd parametros)
        {
            this.Parametros = parametros;
            this.Resultados = new Usuario[] { };
        }

        public FiltrarCmd Parametros { get; set; }

        public Usuario[] Resultados { get; set; }

        private int posicao = -1;
        
        public bool ProximoItem()
        {
            posicao++;
            return this.Resultados.Count() > posicao;
        }

        public int ObterIndice()
        {
            return posicao + 1;
        }

        public string ObterNome() 
        { 
            return string.Format("{0} {1}", this.Resultados[posicao].Nome, this.Resultados[posicao].Sobrenome);
        }

        public string ObterEmail() 
        { 
            return this.Resultados[posicao].Email;
        }
    }
}