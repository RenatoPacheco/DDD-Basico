using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DddBasico.Dominio.Notacoes
{
    public class NaoPodeSerVazioAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (object.Equals(value, null))
                return true;

            string input = Convert.ToString(value);

            return !string.IsNullOrWhiteSpace(input)
                && !Regex.IsMatch(input, @"^[\s ]+$");
        }
    }
}
