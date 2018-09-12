using System;
using System.Text;
using System.Linq;
using System.Reflection;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace DddBasico.Auxiliares.Extensoes
{
    public static class  ExpressionExtensao
    {
        public static PropertyInfo PropInfo<Tipo, Porp>(this Expression<Func<Tipo, Porp>> expressao)
        {
            if ((expressao.Body.NodeType == ExpressionType.Convert) ||
                (expressao.Body.NodeType == ExpressionType.ConvertChecked))
            {
                var unary = expressao.Body as UnaryExpression;
                if (unary != null)
                    return (PropertyInfo)((MemberExpression)unary.Operand).Member;
            }
            return (PropertyInfo)((MemberExpression)expressao.Body).Member;
        }

        public static Type PropTipo<Tipo, Prop>(this Expression<Func<Tipo, Prop>> expressao)
        {
            if ((expressao.Body.NodeType == ExpressionType.Convert) ||
                (expressao.Body.NodeType == ExpressionType.ConvertChecked))
            {
                var unary = expressao.Body as UnaryExpression;
                if (unary != null)
                    return unary.Operand.Type;
            }
            return expressao.Body.Type;
        }

        public static string PropNome<Tipo, Prop>(this Expression<Func<Tipo, Prop>> expressao)
        {
            PropertyInfo propriedade;
            DisplayAttribute atributo = null;
            Type tipo = typeof(Tipo);
            IList<string> props = expressao.ToString().Split('.').ToList();
            if (props.Count() > 1)
                props.RemoveAt(0);

            for (int x = 0; (x + 1) < props.Count(); x++)
            {
                propriedade = tipo.GetProperty(props[x]);
                tipo = propriedade.PropertyType;
            }

            string nome = expressao.Body.PropExtenso() ?? tipo.Name;
            propriedade = tipo.GetProperty(nome);

            if (!object.Equals(propriedade, null))
                atributo = (DisplayAttribute)propriedade.GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault();

            if (!object.Equals(atributo, null))
                nome = atributo.Name;

            return nome;
        }

        public static string PropExtenso<Tipo, Prop>(this Expression<Func<Tipo, Prop>> expressao, bool comTrilha)
        {
            StringBuilder trilha = new StringBuilder();
            string resultado = null;
            PropertyInfo propriedade;
            Type tipo = typeof(Tipo);
            IList<string> props = expressao.ToString().Split('.').ToList();
            if (props.Count() > 1)
                props.RemoveAt(0);

            for (int x = 0; (x + 1) < props.Count(); x++)
            {
                propriedade = tipo.GetProperty(props[x]);
                tipo = propriedade.PropertyType;
                trilha.Append("." + propriedade.Name);
            }

            resultado = expressao.Body.PropExtenso() ?? tipo.Name;
            if (comTrilha)
            {
                trilha.Append("." + resultado);
                resultado = Regex.Replace(trilha.ToString(), @"^\.", "");
            }
            return resultado;
        }

        public static string PropExtenso(this Expression expressao)
        {
            if (expressao is MemberExpression)
            {
                return ((MemberExpression)expressao).Member.Name;
            }
            else if (expressao is UnaryExpression)
            {
                var op = ((UnaryExpression)expressao).Operand;
                return ((MemberExpression)op).Member.Name;
            }

            return null;
        }
        
        public static string PropExtensoComTrilha(this Expression objeto)
        {
            string nome = objeto.ToString();
            if (Regex.IsMatch(nome, @"^[^\.]+.+"))
            {
                return Regex.Replace(nome, @"^[^\.]+\.", "");
            }
            else if (objeto is MemberExpression)
            {
                return ((MemberExpression)objeto).Member.Name;
            }
            else if (objeto is UnaryExpression)
            {
                var op = ((UnaryExpression)objeto).Operand;
                return ((MemberExpression)op).Member.Name;
            }

            return null;
        }
    }
}
