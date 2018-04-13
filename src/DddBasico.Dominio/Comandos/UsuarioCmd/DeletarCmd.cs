
using System;
namespace DddBasico.Dominio.Comandos.UsuarioCmd
{
    public class DeletarCmd : Comum.GuidIdCmd
    {
        public DeletarCmd()
            : base() { }

        public DeletarCmd(Guid? id)
            : base(id) { }
    }
}
