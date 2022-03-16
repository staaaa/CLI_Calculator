using System;
using System.Collections.Generic;
using System.Linq;
using org.mariuszgromada.math.mxparser;

namespace Kalkulator_konsola
{
    public class Calculator
    {
        private string input;
        private IDictionary<string, Argument> dictArgs;

        public Calculator()
        {
            dictArgs = new Dictionary<string, Argument>();
        }

        public void SetInput(string value)
        {
            input = value;
        }

        public void Evaluate()
        {
            if (input.Contains("arg") && input.Split(" ").Length == 3 && input.Contains("clear") == false)
            {
                AddVar(input.Split(' ').Skip(1).FirstOrDefault(), float.Parse(input.Split(' ').Skip(2).FirstOrDefault()));
            }
            else if (input.Contains("arg ") && input.Split(" ").Length == 2)
            {
                ShowArgument(input.Split(" ").Skip(1).First());
            }
            else if (input.Contains("args show") && input.Split(" ").Length == 2)
            {
                ShowAllArguments();
            }
            else if (dictArgs.Keys.Any(Key => input.Contains(Key)) && input.Split(' ').Length == 1)
            {
                ShowArgument(input);
            }
            else if (input.Contains("calc") || input.Split(' ').FirstOrDefault() == "=")
            {
                Calc(input.Substring(input.IndexOf(' ')),dictArgs.Values.ToArray());
            }
            else if (input.Contains("args clear") && input.Split(' ').Length == 2)
            {
                DropAllArguments();
            }
            else if (input.Contains("arg") && input.Contains("clear") && input.Split(' ').Length == 3)
            {
                DropOneArgument(input.Split(" ").Skip(1).First());
            }
            else if(input.Contains("clear") && input.Split(' ').Length == 1)
            {
                Clear();
            }
            else if(input.Contains("help") && input.Split(' ').Length == 1)
            {
                Help();
            }
        }

        private void AddVar(string varName, float varValue)
        {
            dictArgs.Add(varName, new Argument(varName + "=" + varValue.ToString()));
            Console.WriteLine("Dodano argument.");
        }

        private void ShowArgument(string varName)
        {
            Console.WriteLine(dictArgs[varName].getArgumentName() + " = " + dictArgs[varName].getArgumentValue().ToString());
        }

        private void ShowAllArguments()
        {
            foreach (KeyValuePair<string, Argument> a in dictArgs)
            {
                Console.WriteLine(a.Value.getArgumentName() + " = " + a.Value.getArgumentValue().ToString());
            }
        }

        private void Calc(string operation, params Argument[] args)
        {
            Console.WriteLine(new Expression(operation, args).calculate());
        }

        private void DropAllArguments()
        {
            dictArgs.Clear();
            Console.WriteLine("Usunięto wszystkie argumenty.");
        }

        private void DropOneArgument(string key)
        {
            dictArgs.Remove(key);
            Console.WriteLine("Usunięto argument o nazwie " + key);
        }

        private void Clear()
        {
            Console.Clear();
        }

        private void ColorConsoleWrite(string colorText, string whiteText)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(colorText);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(whiteText);
        }

        private void Help()
        {
            Console.WriteLine("Oto lista dostępnych formuł:");
            ColorConsoleWrite("1. arg [nazwa_zmiennej] [wartosc_zmiennej] ", "- dodaje zmienna o podanej wartości.");
            ColorConsoleWrite("2. arg [nazwa_zmiennej] ", "- wypisuje wartość zmiennej o podanej nazwie.");
            ColorConsoleWrite("3.  args show" , "- dodaje zmienna o podanej wartości.");
            ColorConsoleWrite("4. args clear ", "- usuwa wszystkie wcześniej zadeklarowane zmienne.");
            ColorConsoleWrite("5. = [nazwa_zmiennej] ", "- wypisuje wartość zmiennej o podanej nazwie.");
            ColorConsoleWrite("6. [nazwa_zmiennej] ", "- wypisuje wartość zmiennej o podanej nazwie.");
            ColorConsoleWrite("7. calc [wyrażenie] ", "- oblicza podane wyrażenie.");
            ColorConsoleWrite("8. = [wyrażenie] ", "- oblicza podane wyrażenie.");
            ColorConsoleWrite("9. clear ", "- usuwa tekst z terminala.");
            ColorConsoleWrite("10. quit ", "- wyłącza kalkulator.");
            ColorConsoleWrite("11. help ", "- wyświetla liste dostępnych formuł.");
        }

    }
}
