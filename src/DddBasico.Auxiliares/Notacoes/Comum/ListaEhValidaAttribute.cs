using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace DddBasico.Auxiliares.Notacoes.Comum
{
    public abstract class ListaEhValidaAttribute : ValidationAttribute
    {
        public ListaEhValidaAttribute()
         : base("{0} não é válido") { }
        
        public ListaEhValidaAttribute(string mensagem)
            : base(mensagem) { }

        public abstract bool Check(object value);

        public override bool IsValid(object value)
        {
            if (!object.Equals(value, null))
            {
                if (value is IEnumerable && !(value is string))
                {
                    foreach (var item in value as IEnumerable)
                    {
                        if (object.Equals(item, null))
                            continue;
                        else if (!this.Check(item))
                            return false;
                    }
                }
                else
                {
                    return this.Check(value);
                }
            }

            return true;
        }
    }
}
