using System;
using FizzBuzzConsole.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FizzBuzzConsole.MsTest
{
    [TestClass]
    public class FizzBuzzTests
    {
        public FizzBuzz fizzBuzz;

        [TestInitialize]
        public void Initialize()
        {
            this.fizzBuzz = new FizzBuzz();
        }

        private void Validar_Fizz(int value)
        {
            var result = this.fizzBuzz.Validate(value);
            Assert.AreEqual("Fizz", result);
        }

        private void Validar_Buzz(int value)
        {
            var result = this.fizzBuzz.Validate(value);
            Assert.AreEqual("Buzz", result);
        }

        private void Validar_FizzBuzz(int value)
        {
            var result = this.fizzBuzz.Validate(value);
            Assert.AreEqual("FizzBuzz", result);
        }

        private void Validar_Numero(int value)
        {
            var result = this.fizzBuzz.Validate(value);
            Assert.AreEqual(value.ToString(), result);
        }

        [TestCategory("MSTest")]
        [TestMethod]
        public void Validar_Fizz()
        {
            Validar_Fizz(3);
        }

        [TestCategory("MSTest")]
        [TestMethod]
        public void Validar_Buzz()
        {
            Validar_Buzz(5);
        }

        [TestCategory("MSTest")]
        [TestMethod]
        public void Validar_FizzBuzz()
        {
            Validar_FizzBuzz(15);
        }

        [TestCategory("MSTest")]
        [TestMethod]
        public void Validar_Numero()
        {
            Validar_Numero(2);
        }
    }
}
