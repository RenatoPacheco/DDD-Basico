using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.ModelBinding.Binders;
using DddBasico.Api.App_Start.DataBinding;

namespace DddBasico.Api
{
    public class DataBindingConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Services.Insert(typeof(ModelBinderProvider), 0,
                new SimpleModelBinderProvider(typeof(DateTime?), new DateTimeModelBinder()));

            config.Services.Insert(typeof(ModelBinderProvider), 0,
                new SimpleModelBinderProvider(typeof(DateTime), new DateTimeModelBinder()));
        }
    }
}