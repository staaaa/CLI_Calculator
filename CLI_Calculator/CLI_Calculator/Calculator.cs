using System;
using System.Collections.Generic;
using System.Linq;
using CLI_Calculator;
using org.mariuszgromada.math.mxparser;

namespace Kalkulator_konsola
{
    public class Calculator: OutputInput
    {
        private string input;
        private IDictionary<string, Argument> dictArgs;
        private Conditions conditions;
        private OutputInput oi;

        public Calculator(Conditions _conditions, OutputInput _outputInput)
        {
            dictArgs = new Dictionary<string, Argument>();
            conditions = _conditions;
            oi = _outputInput;
        }
        public void SetInput(string value)
        {
            input = value;
        }

        public string GetInput()
        {
            return input;
        }

        public IDictionary<string, Argument> GetDictArgs()
        {
            return dictArgs;
        }

        public void Evaluate()
        {
            if (conditions.IfAddVar(input))
            {
                AddVar(input.Split(' ').Skip(1).FirstOrDefault(), float.Parse(input.Split(' ').Skip(2).FirstOrDefault()));
            }
            else if (conditions.IfShowArgument(input))
            {
                ShowArgument(input.Split(" ").Skip(1).First());
            }
            else if (conditions.IfShowAllArguments(input))
            {
                ShowAllArguments();
            }
            else if (conditions.IfShowArgumentFromName(input,dictArgs))
            {
                ShowArgument(input);
            }
            else if (conditions.IfCalc(input))
            {
                Calc(input.Substring(input.IndexOf(' ')),dictArgs.Values.ToArray());
            }
            else if (conditions.IfDropAllArguments(input))
            {
                DropAllArguments();
            }
            else if (conditions.IfDropOneArgument(input))
            {
                DropOneArgument(input.Split(" ").Skip(1).First());
            }
            else if(conditions.IfClear(input))
            {
                Clear();
            }
            else if(conditions.IfHelp(input))
            {
                Help();
            }
        }

        private void AddVar(string varName, float varValue)
        {
            dictArgs.Add(varName, new Argument(varName + "=" + varValue.ToString()));
            oi.WriteOutputWithBreakRow("Dodano argument.");
        }

        private void ShowArgument(string varName)
        {
            try
            {
                oi.WriteOutputWithBreakRow(dictArgs[varName].getArgumentName() + " = " + dictArgs[varName].getArgumentValue().ToString());
            }
            catch
            {
                oi.WriteOutputWithBreakRow("Podany argument nie istnieje.");
            }
        }

        private void ShowAllArguments()
        {
            foreach (KeyValuePair<string, Argument> a in dictArgs)
            {
                oi.WriteOutputWithBreakRow(a.Value.getArgumentName() + " = " + a.Value.getArgumentValue().ToString());
            }
        }

        private void Calc(string operation, params Argument[] args)
        {
            oi.WriteOutputWithBreakRow(new Expression(operation, args).calculate().ToString());
        }

        private void DropAllArguments()
        {
            dictArgs.Clear();
            oi.WriteOutputWithBreakRow("Usunięto wszystkie argumenty.");
        }

        private void DropOneArgument(string key)
        {
            dictArgs.Remove(key);
            oi.WriteOutputWithBreakRow("Usunięto argument o nazwie " + key);
        }

        private void Clear()
        {
            Console.Clear();
        }

        private void ColorConsoleWrite(string colorText, string whiteText)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            oi.WriteOutputWithoutBreakRow(colorText);
            Console.ForegroundColor = ConsoleColor.White;
            oi.WriteOutputWithBreakRow(whiteText);
        }

        private void Help()
        {
            oi.WriteOutputWithBreakRow("Oto lista dostępnych formuł:");
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
