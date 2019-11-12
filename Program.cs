using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var question1 = "3 + 5 * 2";
            var question2 = "2 * 2";
            var question3 = "1 + 2 + 3";
            var question4 = "6 / 2";
            var question5 = "11 + 23";
            var question6 = "11.1 + 23";
            var question7 = "1 + 1 * 3";
            var question8 = "(11.5 + 15.4) + 10.1";
            var question9 = "23 - ( 29.3 - 12.5 )";
            var question10 = "10 - ( 2 + 3 * ( 7 - 5 ) )";

            Console.WriteLine($"Answer {question1} = " + Helpers.Calculator.Calculate(question1));
            Console.WriteLine($"Answer {question2} = " + Helpers.Calculator.Calculate(question2));
            Console.WriteLine($"Answer {question3} = " + Helpers.Calculator.Calculate(question3));
            Console.WriteLine($"Answer {question4} = " + Helpers.Calculator.Calculate(question4));
            Console.WriteLine($"Answer {question5} = " + Helpers.Calculator.Calculate(question5));
            Console.WriteLine($"Answer {question6} = " + Helpers.Calculator.Calculate(question6));
            Console.WriteLine($"Answer {question7} = " + Helpers.Calculator.Calculate(question7));
            Console.WriteLine($"Answer {question8} = " + Helpers.Calculator.Calculate(question8));
            Console.WriteLine($"Answer {question9} = " + Helpers.Calculator.Calculate(question9));
            Console.WriteLine($"Answer {question10} = " + Helpers.Calculator.Calculate(question10));
            Console.ReadKey();
        }
    }
}
