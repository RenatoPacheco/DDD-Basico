using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace DddBasico.Auxiliares.Notacoes
{
    [AttributeUsage(AttributeTargets.Property |
        AttributeTargets.Field, AllowMultiple = false)]
    public class EhRequeridoAttribute : ValidationAttribute
    {
        public EhRequeridoAttribute()
            : base("{0} é obrigatório") { }

        public EhRequeridoAttribute(bool ignorarNuloOuListaVazia)
            : this()
        {
            this.IgnorarNuloOuListaVazia = ignorarNuloOuListaVazia;
        }

        public bool IgnorarNuloOuListaVazia { get; set; }

        public virtual bool Check(object value)
        {
            if (this.IgnorarNuloOuListaVazia && object.Equals(value, null))
                return true;
            else if (object.Equals(value, null))
                return false;

            string input = Convert.ToString(value);
            return !Regex.IsMatch(input, @"^[\s ]+$") && !string.IsNullOrEmpty(input);
        }

        public override bool IsValid(object value)
        {
            bool haItens = false;
            if (!object.Equals(value, null))
            {
                if (value is IEnumerable && !(value is string))
                {
                    foreach (var item in value as IEnumerable)
                    {
                        haItens = true;
                        if (object.Equals(item, null) || !this.Check(item))
                            return false;
                    }
                    return haItens || this.IgnorarNuloOuListaVazia;
                }
                else
                {
                    return this.Check(value);
                }
            }

            return this.IgnorarNuloOuListaVazia || !object.Equals(value, null);
        }
    }
}