using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzConsole.Utils
{
    public class FizzBuzz
    {
        public string Validate(int value)
        {
            var fizz = (value % 3) == 0;
            var buzz = (value % 5) == 0;

            if (fizz && buzz)
                return "FizzBuzz";
            else if (fizz)
                return "Fizz";
            else if (buzz)
                return "Buzz";
            else if (value < 0)
                return string.Empty;
            else
                return value.ToString();
        }
    }
}
