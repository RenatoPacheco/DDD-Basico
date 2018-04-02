using DddBasico.Dominio.Interfaces.Validacao;

namespace DddBasico.Dominio.Interfaces.Repositorios.Comum
{
    public interface IRepositorio<Entidade, Identificador> : IAutoValidacao
        where Entidade : class
    {
        void Inserir(Entidade entidade);

        void Atualizar(Entidade entidade);

        void Deletar(Entidade entidade);

        Entidade Obter(Identificador id);

        Entidade[] Listar();
    }
}
