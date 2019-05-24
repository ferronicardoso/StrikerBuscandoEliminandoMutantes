using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mono.Cecil;
using TesteMutacao.Exemplo;

namespace TesteMutacao.Tests
{
    [TestClass]
    public class CalculadoraTests
    {
        private Calculadora calculadora;

        [TestInitialize]
        public void Init()
        {
            this.calculadora = new Calculadora();
        }

        [TestMethod]
        public void Somar()
        {
            var result = this.calculadora.Somar(2, 4);
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void Subtrair()
        {
            var result = this.calculadora.Subtrair(12, 8);
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void Multiplicar()
        {
            var result = this.calculadora.Multiplicar(10, 5);
            Assert.AreEqual(50, result);
        }

        [TestMethod]
        public void Dividir()
        {
            var result = this.calculadora.Dividir(100, 4);
            Assert.AreEqual(25, result);
        }

        [TestMethod]
        public void Dividir_Sucesso()
        {
            try
            {
                var result = this.calculadora.Dividir(1, 1);
                Assert.AreEqual(1, result);
            }
            catch
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod, ExpectedException(typeof(DivideByZeroException))]
        public void Dividir_Exception()
        {
            this.calculadora.Dividir(1, 0);
        }

        [TestMethod]
        public void Dividir_Por_Zero()
        {
            try
            {
                this.calculadora.Dividir(1, 0);
            }
            catch(Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("dividir por zero"));
            }
        }
    }
}
