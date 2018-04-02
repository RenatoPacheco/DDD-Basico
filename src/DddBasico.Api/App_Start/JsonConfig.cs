using DddBasico.Api.App_Start.JsonCustom;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace DddBasico.Api
{
    public static class JsonConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Ref: http://waldyrfelix.net/2013/04/29/asp-net-web-api-melhorando-o-retorno-json-dos-seus-servicos-rest/

            // Remove formato XML
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Formatando json
            var json = config.Formatters.JsonFormatter;
            json.SupportedMediaTypes.Clear();
            json.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/json"));
            // json.Indent = true;
            // json.SerializerSettings.Formatting = Formatting.Indented;
            // json.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            // json.SerializerSettings.ObjectCreationHandling = ObjectCreationHandling.Replace;
            // json.SerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
            json.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            json.SerializerSettings.Culture = System.Globalization.CultureInfo.CurrentCulture;
            //json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.All;
            json.SerializerSettings.ContractResolver = new CustomContractResolver();
            // json.UseDataContractJsonSerializer = false
            json.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
        }
    }
}