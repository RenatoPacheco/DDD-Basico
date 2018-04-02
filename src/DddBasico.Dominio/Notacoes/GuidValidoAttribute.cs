﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DddBasico.Dominio.Notacoes
{
    public class GuidValidoAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (object.Equals(value, null))
                return true;

            string input = Convert.ToString(value);

            return !string.IsNullOrWhiteSpace(input)
                && Regex.IsMatch(input, @"^[a-z0-9]{8}(-[a-z0-9]{4}){3}-[a-z0-9]{12}$", RegexOptions.IgnoreCase)
                && !Regex.IsMatch(input, @"^[0]{8}(-[0]{4}){3}-[0]{12}$", RegexOptions.IgnoreCase);
        }
    }
}
