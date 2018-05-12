using DddBasico.Dominio.Comandos.UsuarioCmd;
using System;

namespace DddBasico.Api.Models.UsuarioModel
{
    public class AtualizarModel : AtualizarCmd
    {
        public AtualizarModel()
            : base()
        {
            this.Id = Guid.NewGuid();
        }
    }
}