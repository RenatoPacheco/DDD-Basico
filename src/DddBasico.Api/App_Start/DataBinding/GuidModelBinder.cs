using DddBasico.Auxiliares.Mensagens;
using System;
using System.Globalization;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using System.Web.Http.ValueProviders;

namespace DddBasico.Api.App_Start.DataBinding
{
    public class GuidModelBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType != typeof(Guid?)
                && bindingContext.ModelType != typeof(Guid))
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
                    bindingContext.ModelName, string.Format(ValidacaoMsg.GuidInvalido, bindingContext.ModelName));
                return true;
            }
                        
            Guid result;
            if(TryParse(key, out result))
            {
                bindingContext.Model = result;
                return true;
            }        

            bindingContext.ModelState.AddModelError(
            bindingContext.ModelName, string.Format(ValidacaoMsg.GuidInvalido, bindingContext.ModelName));
            return true;
        }

        public bool TryParse(string value, out Guid result)
        {
            return Guid.TryParse(value, out result);
        }
    }
}