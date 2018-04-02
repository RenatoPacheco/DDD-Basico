using System;
using System.Globalization;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using System.Web.Http.ValueProviders;

namespace DddBasico.Api.App_Start.DataBinding
{
    public class DateTimeModelBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType != typeof(DateTime?) 
                && bindingContext.ModelType != typeof(DateTime))
            {
                return false;
            }

            ValueProviderResult val = bindingContext.ValueProvider.GetValue(
                bindingContext.ModelName);
            if (val == null)
            {
                return false;
            }

            string key = val.RawValue as string;
            if (key == null)
            {
                bindingContext.ModelState.AddModelError(
                    bindingContext.ModelName, "Tipo de valor errado");
                return true;
            }
                        
            DateTime result;
            if(TryParse(key, out result))
            {
                bindingContext.Model = result;
                return true;
            }        

            bindingContext.ModelState.AddModelError(
            bindingContext.ModelName, string.Format("O Valor '{0}' não é válido.", key));
            return true;
        }

        public bool TryParse(string value, out DateTime result)
        {
            DateTimeStyles styles = DateTimeStyles.NoCurrentDateDefault;
            IFormatProvider provider = null;
            string[] formats = new string[]
            {
                "dd/MM/yyyy HH:mm:ss",
                "dd/MM/yyyy",
                "dd-MM-yyyy HH:mm:ss",
                "dd-MM-yyyy",
                "yyyy/MM/dd HH:mm:ss",
                "yyyy/MM/dd",
                "yyyy-MM-dd HH:mm:ss",
                "yyyy-MM-dd"
            };

            foreach (string format in formats)
            {
                if (DateTime.TryParseExact(
                            value,
                            format,
                            provider,
                            styles,
                            out result))
                {
                    return true;
                }
            }

            result = new DateTime();
            return false;
        }
    }
}