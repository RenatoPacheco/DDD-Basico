using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace DddBasico.Dominio.Notacoes.Comum
{
    public abstract class ListaEhValidaAttribute : ValidationAttribute
    {
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
