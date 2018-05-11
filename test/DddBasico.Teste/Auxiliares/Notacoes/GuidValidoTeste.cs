using System;
using DddBasico.Auxiliares.Notacoes;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DddBasico.Teste.Auxiliares.Notacoes
{
    [TestClass]
    public class GuidValidoTeste
    {
        [TestMethod]
        public void Reprovar_formato_invalido()
        {
            GuidValidoAttribute validar = new GuidValidoAttribute();
            Assert.IsFalse(validar.IsValid("121212121212"));
            Assert.IsFalse(validar.IsValid(new List<string>() { "4545454545454", Guid.NewGuid().ToString() }));
            Assert.IsFalse(validar.IsValid(new string[] { "4545454545454", Guid.NewGuid().ToString() }));
        }

        [TestMethod]
        public void Reprovar_guid_so_com_0()
        {
            GuidValidoAttribute validar = new GuidValidoAttribute();
            Assert.IsFalse(validar.IsValid(Guid.Empty));
            Assert.IsFalse(validar.IsValid(new List<string>() { Guid.Empty.ToString(), Guid.NewGuid().ToString() }));
            Assert.IsFalse(validar.IsValid(new string[] { Guid.Empty.ToString(), Guid.NewGuid().ToString() }));
            Assert.IsFalse(validar.IsValid(new List<Guid>() { Guid.Empty, Guid.NewGuid() }));
            Assert.IsFalse(validar.IsValid(new Guid[] { Guid.Empty, Guid.NewGuid() }));
        }

        [TestMethod]
        public void Reprovar_guid_vazio()
        {
            GuidValidoAttribute validar = new GuidValidoAttribute();
            Assert.IsFalse(validar.IsValid("          "));
            Assert.IsFalse(validar.IsValid(new List<string>() { "          ", Guid.NewGuid().ToString() }));
            Assert.IsFalse(validar.IsValid(new string[] { "          ", Guid.NewGuid().ToString() }));
        }

        [TestMethod]
        public void Reprovar_guid_em_branco()
        {
            GuidValidoAttribute validar = new GuidValidoAttribute();
            Assert.IsFalse(validar.IsValid(string.Empty));
            Assert.IsFalse(validar.IsValid(new List<string>() { string.Empty, Guid.NewGuid().ToString() }));
            Assert.IsFalse(validar.IsValid(new string[] { string.Empty, Guid.NewGuid().ToString() }));
        }

        [TestMethod]
        public void Aprovar_valor_nulo()
        {
            GuidValidoAttribute validar = new GuidValidoAttribute();
            Assert.IsTrue(validar.IsValid(null));
            Assert.IsTrue(validar.IsValid(new List<string>() { null, Guid.NewGuid().ToString() }));
            Assert.IsTrue(validar.IsValid(new string[] { null, Guid.NewGuid().ToString() }));
            Assert.IsTrue(validar.IsValid(new List<Guid?>() { null, Guid.NewGuid() }));
            Assert.IsTrue(validar.IsValid(new Guid?[] { null, Guid.NewGuid() }));
        }

        [TestMethod]
        public void Aprovar_valor_valido()
        {
            GuidValidoAttribute validar = new GuidValidoAttribute();
            Assert.IsTrue(validar.IsValid(Guid.NewGuid()));
            Assert.IsTrue(validar.IsValid(new List<string>() { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() }));
            Assert.IsTrue(validar.IsValid(new string[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() }));
            Assert.IsTrue(validar.IsValid(new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() }));
            Assert.IsTrue(validar.IsValid(new Guid[] { Guid.NewGuid(), Guid.NewGuid() }));
        }
    }
}
