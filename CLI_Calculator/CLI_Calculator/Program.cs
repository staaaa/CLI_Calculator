using org.mariuszgromada.math.mxparser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kalkulator_konsola
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            while (true)
            {
                var command = Console.ReadLine().ToLower();
                if (command == "quit")
                {
                    break;
                }
                else
                {
                    calc.SetInput(command);
                    calc.Evaluate();
                }
            }
        }
    }
}