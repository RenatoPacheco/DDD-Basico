using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DddBasico.Auxiliares.Notacoes;
using System.Collections.Generic;

namespace DddBasico.Teste.Auxiliares.Notacoes
{
    [TestClass]
    public class EhRequeridoTeste
    {
        #region Validar indicando para ignorar valor nulo

        [TestMethod]
        public void Aprovar_valor_nulo_indicando_para_ignorar_nulo_ou_lista_vazia()
        {
            RequeridoAttribute validar = new RequeridoAttribute(true);
            Assert.IsTrue(validar.IsValid(null));
        }

        [TestMethod]
        public void Reprovar_valor_vazio_indicando_para_ignorar_nulo_ou_lista_vazia()
        {
            RequeridoAttribute validar = new RequeridoAttribute(true);
            Assert.IsFalse(validar.IsValid(string.Empty));
        }

        [TestMethod]
        public void Reprovar_valor_som_com_espacos_em_branco_indicando_para_ignorar_nulo_ou_lista_vazia()
        {
            RequeridoAttribute validar = new RequeridoAttribute(true);
            Assert.IsFalse(validar.IsValid("          "));
        }

        [TestMethod]
        public void Aprovar_lista_vazio_indicando_para_ignorar_nulo_ou_lista_vazia()
        {
            RequeridoAttribute validar = new RequeridoAttribute(true);
            Assert.IsTrue(validar.IsValid(new string[] { }));
            Assert.IsTrue(validar.IsValid(new List<string>()));
        }

        [TestMethod]
        public void Reprovar_lista_com_item_vazio_indicando_para_ignorar_nulo_ou_lista_vazia()
        {
            RequeridoAttribute validar = new RequeridoAttribute(true);
            Assert.IsFalse(validar.IsValid(new string[] { string.Empty }));
            Assert.IsFalse(validar.IsValid(new List<string>() { string.Empty }));
        }

        [TestMethod]
        public void Reprovar_lista_com_item_invalido_indicando_para_ignorar_nulo_ou_lista_vazia()
        {
            RequeridoAttribute validar = new RequeridoAttribute(true);
            Assert.IsFalse(validar.IsValid(new string[] { "      " }));
            Assert.IsFalse(validar.IsValid(new List<string>() { "        " }));
        }

        [TestMethod]
        public void Reprovar_lista_com_item_nulo_indicando_para_ignorar_nulo_ou_lista_vazia()
        {
            RequeridoAttribute validar = new RequeridoAttribute(true);
            Assert.IsFalse(validar.IsValid(new string[] { null }));
            Assert.IsFalse(validar.IsValid(new List<string>() { null }));
        }

        [TestMethod]
        public void Aprovar_valor_valido_indicando_para_ignorar_nulo_ou_lista_vazia()
        {
            RequeridoAttribute validar = new RequeridoAttribute(true);
            Assert.IsTrue(validar.IsValid("123"));
            Assert.IsTrue(validar.IsValid(new string[] { "123" }));
            Assert.IsTrue(validar.IsValid(new List<string>() { "123" }));
        }

        #endregion

        #region Validar sem indicar para ignorar valor nulo

        [TestMethod]
        public void Reprovar_valor_nulo()
        {
            RequeridoAttribute validar = new RequeridoAttribute();
            Assert.IsFalse(validar.IsValid(null));
        }

        [TestMethod]
        public void Reprovar_valor_vazio()
        {
            RequeridoAttribute validar = new RequeridoAttribute();
            Assert.IsFalse(validar.IsValid(string.Empty));
        }

        [TestMethod]
        public void Reprovar_valor_som_com_espacos_em_branco()
        {
            RequeridoAttribute validar = new RequeridoAttribute();
            Assert.IsFalse(validar.IsValid("          "));
        }

        [TestMethod]
        public void Reprovar_array_vazio()
        {
            RequeridoAttribute validar = new RequeridoAttribute();
            Assert.IsFalse(validar.IsValid(new string[] { }));
            Assert.IsFalse(validar.IsValid(new List<string>() { }));
        }

        [TestMethod]
        public void Reprovar_array_com_item_vazio()
        {
            RequeridoAttribute validar = new RequeridoAttribute();
            Assert.IsFalse(validar.IsValid(new string[] { string.Empty }));
            Assert.IsFalse(validar.IsValid(new List<string>() { string.Empty }));
        }

        [TestMethod]
        public void Reprovar_lista_com_item_invalido()
        {
            RequeridoAttribute validar = new RequeridoAttribute();
            Assert.IsFalse(validar.IsValid(new string[] { "        " }));
            Assert.IsFalse(validar.IsValid(new List<string>() { "        " }));
        }

        [TestMethod]
        public void Reprovar_lista_com_item_nulo()
        {
            RequeridoAttribute validar = new RequeridoAttribute();
            Assert.IsFalse(validar.IsValid(new string[] { null }));
            Assert.IsFalse(validar.IsValid(new List<string>() { null }));
        }

        [TestMethod]
        public void Aprovar_valor_valido()
        {
            RequeridoAttribute validar = new RequeridoAttribute();
            Assert.IsTrue(validar.IsValid("123"));
            Assert.IsTrue(validar.IsValid(new string[] { "123" }));
            Assert.IsTrue(validar.IsValid(new List<string>() { "123" }));
        }

        #endregion
    }
}
