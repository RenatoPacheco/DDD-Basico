using DddBasico.Auxiliares.Interfaces.Validacao;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DddBasico.Auxiliares.Validacao
{
    public class Validacao<Tipo> : IValidacao<Tipo>
        where Tipo : class
    {
        public INotificarValidacao Validar(Tipo entidade)
        {
            INotificarValidacao resultado = new NotificarValidacao();
            var contexto = new ValidationContext(entidade, serviceProvider: null, items: null);
            var lista = new List<ValidationResult>();
            var ehValido = Validator.TryValidateObject(entidade, contexto, lista, true);
            if (!ehValido)
                lista.ForEach(item => resultado.Adicionar(item.ErrorMessage.ToString(), item.MemberNames.ElementAt(0)));

            return resultado;
        }
    }
}
