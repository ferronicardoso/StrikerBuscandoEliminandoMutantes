using FizzBuzzConsole.Utils;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        public FizzBuzz fizzBuzz;
        
        [SetUp]
        public void Setup()
        {
            this.fizzBuzz = new FizzBuzz();
        }
        
        [TestCase(3)]
        [TestCase(6)]
        [TestCase(9)]
        [TestCase(12)]
        [TestCase(18)]
        [TestCase(21)]
        [Category("NUnit")]
        public void Validar_Fizz(int value)
        {
            var result = this.fizzBuzz.Validate(value);
            Assert.AreEqual("Fizz", result);
        }
        
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(20)]
        [TestCase(25)]
        [TestCase(35)]
        [Category("NUnit")]
        public void Validar_Buzz(int value)
        {
            var result = this.fizzBuzz.Validate(value);
            Assert.AreEqual("Buzz", result);
        }
        
        [TestCase(15)]
        [TestCase(30)]
        [TestCase(45)]
        [TestCase(60)]
        [Category("NUnit")]
        public void Validar_FizzBuzz(int value)
        {
            var result = this.fizzBuzz.Validate(value);
            Assert.AreEqual("FizzBuzz", result);
        }
        
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(4)]
        [TestCase(7)]
        [TestCase(8)]
        [Category("NUnit")]
        public void Validar_Numero(int value)
        {
            var result = this.fizzBuzz.Validate(value);
            Assert.AreEqual(value.ToString(), result);
        }
    }
}