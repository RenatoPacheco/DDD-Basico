
using DddBasico.Dominio.Entidades;
using System;
namespace DddBasico.Dominio.Comandos.UsuarioCmd
{
    public class DeletarCmd : Comum.GuidIdCmd
    {
        public DeletarCmd()
            : base() { }

        public DeletarCmd(Guid? id)
            : base(id) { }

        public void Desfazer(ref Usuario dados)
        {
            dados = null;
        }
    }
}
