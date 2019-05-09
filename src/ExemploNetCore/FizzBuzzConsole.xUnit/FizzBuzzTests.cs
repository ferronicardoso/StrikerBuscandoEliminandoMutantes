using FizzBuzzConsole.Utils;
using System;
using Xunit;

namespace FizzBuzzConsole.xUnit
{
    public class FizzBuzzTests
    {
        public readonly FizzBuzz fizzBuzz;
        
        public FizzBuzzTests()
        {
            this.fizzBuzz = new FizzBuzz();
        }

        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        [InlineData(9)]
        [InlineData(12)]
        [InlineData(18)]
        [InlineData(21)]
        public void Validar_Fizz(int value)
        {
            var result = this.fizzBuzz.Validate(value);
            Assert.Equal("Fizz", result);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(20)]
        [InlineData(25)]
        [InlineData(35)]
        public void Validar_Buzz(int value)
        {
            var result = this.fizzBuzz.Validate(value);
            Assert.Equal("Buzz", result);
        }

        [Theory]
        [InlineData(15)]
        [InlineData(30)]
        [InlineData(45)]
        [InlineData(60)]
        public void Validar_FizzBuzz(int value)
        {
            var result = this.fizzBuzz.Validate(value);
            Assert.Equal("FizzBuzz", result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(7)]
        [InlineData(8)]
        public void Validar_Numero(int value)
        {
            var result = this.fizzBuzz.Validate(value);
            Assert.Equal(value.ToString(), result);
        }
    }
}
