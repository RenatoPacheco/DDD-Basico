
using System;
namespace DddBasico.Dominio.Comandos.UsuarioCmd
{
    public class ObterCmd : Comum.GuidIdCmd
    {
        public ObterCmd()
            : base() { }

        public ObterCmd(Guid? id)
            : base(id) { }
    }
}
