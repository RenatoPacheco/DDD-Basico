using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DddBasico.Dominio.Entidades
{
    public class Usuario
    {
        public Usuario() 
        {
            this.Id = Guid.NewGuid();
        }

        public Usuario(
            string nome, 
            string sobrenome, 
            string email)
            : this(nome, sobrenome, email, null) { }

        public Usuario(
            string nome,
            string sobrenome,
            string email,
            string senha)
            : this()
        {
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.Email = email;
            this.Senha = senha;
        }

        [Display(Name = "Usuário")]
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }
        
        [Display(Name="E-mail")]
        public string Email { get; set; }

        public string Senha { get; set; }
    }
}
