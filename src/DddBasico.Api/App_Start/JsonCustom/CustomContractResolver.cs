using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using DddBasico.Dominio.Interfaces.Validacao;

namespace DddBasico.Api.App_Start.JsonCustom
{
    public class CustomContractResolver : DefaultContractResolver
    {
        public CustomContractResolver()
            : base()
        {
            // Aplicar o comportamento de CamelCasePropertyNamesContractResolver
            NamingStrategy = new CamelCaseNamingStrategy
            {
                ProcessDictionaryKeys = true,
                OverrideSpecifiedNames = true
            };
        }

        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> properties = base.CreateProperties(type, memberSerialization);
            var actualProperties = type.GetProperties();
            bool isList = false;
            Type realType;

            foreach (JsonProperty jsonProperty in properties)
            {
                var property = actualProperties.FirstOrDefault(x => x.Name.ToLower() == jsonProperty.PropertyName.ToLower());
                isList = property.PropertyType.IsGenericType && property.PropertyType != typeof(string);
                realType = isList ? property.PropertyType.GetGenericArguments()[0] 
                    : property.PropertyType.IsArray ? property.PropertyType.GetElementType() : property.PropertyType;

                if(property != null)
                {
                    if (property.GetCustomAttribute(typeof(JsonIgnoreAttribute)) != null || property.PropertyType == typeof(INotificarValidacao))
                    {
                        jsonProperty.Ignored = true;
                    }
                }
            }
            return properties;
        
        }
        protected override JsonContract CreateContract(Type objectType)
        {
            return base.CreateContract(objectType);
        }
    }
}