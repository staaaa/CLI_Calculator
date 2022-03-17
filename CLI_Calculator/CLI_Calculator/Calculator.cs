using System;
using System.Collections.Generic;
using System.Linq;
using CLI_Calculator;
using org.mariuszgromada.math.mxparser;

namespace Kalkulator_konsola
{
    public class Calculator:Conditions
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

        public IDictionary<string, Argument> GetDictArgs()
        {
            return dictArgs;
        }

        public void Evaluate()
        {
            if (IfAddVar(input))
            {
                AddVar(input.Split(' ').Skip(1).FirstOrDefault(), float.Parse(input.Split(' ').Skip(2).FirstOrDefault()));
            }
            else if (IfShowArgument(input))
            {
                ShowArgument(input.Split(" ").Skip(1).First());
            }
            else if (IfShowAllArguments(input))
            {
                ShowAllArguments();
            }
            else if (IfShowArgumentFromName(input,dictArgs))
            {
                ShowArgument(input);
            }
            else if (IfCalc(input))
            {
                Calc(input.Substring(input.IndexOf(' ')),dictArgs.Values.ToArray());
            }
            else if (IfDropAllArguments(input))
            {
                DropAllArguments();
            }
            else if (IfDropOneArgument(input))
            {
                DropOneArgument(input.Split(" ").Skip(1).First());
            }
            else if(IfClear(input))
            {
                Clear();
            }
            else if(IfHelp(input))
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
