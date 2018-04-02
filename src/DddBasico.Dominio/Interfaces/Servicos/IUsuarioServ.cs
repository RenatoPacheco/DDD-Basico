using DddBasico.Dominio.Comandos.Comum;
using DddBasico.Dominio.Comandos.UsuarioCmd;
using DddBasico.Dominio.Entidades;
using DddBasico.Dominio.Interfaces.Validacao;

namespace DddBasico.Dominio.Interfaces.Servicos
{
    public interface IUsuarioServ : IAutoValidacao
    {
        Usuario Inserir(InserirCmd comando);

        Usuario Atualizar(AtualizarCmd comando);

        Usuario Obter(GuidIdCmd comando);
        
        Usuario[] Listar();

        Usuario Deletar(GuidIdCmd comando);
    }
}
