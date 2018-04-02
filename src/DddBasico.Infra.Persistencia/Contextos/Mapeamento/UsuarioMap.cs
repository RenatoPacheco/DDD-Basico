using DapperExtensions.Mapper;
using DddBasico.Dominio.Entidades;
using System;

namespace DddBasico.Infra.Persistencia.Contextos.Mapeamento
{
    public class UsuarioMap : ClassMapper<Usuario>
    {
        public UsuarioMap()
        {
            Table("Usuario");

            Map(x => x.Id).Column("Id").Key(KeyType.Guid);
            Map(x => x.Nome).Column("Nome");
            Map(x => x.Sobrenome).Column("Sobrenome");
            Map(x => x.Email).Column("Email");
            Map(x => x.Senha).Column("Senha");
        }
    }
}
