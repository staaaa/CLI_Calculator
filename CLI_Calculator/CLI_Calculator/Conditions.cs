using System;
using System.Collections.Generic;
using System.Linq;
using org.mariuszgromada.math.mxparser;

namespace CLI_Calculator
{
    public abstract class Conditions
    {
        public bool IfAddVar(string input)
        {
            if (input.Contains("arg") && input.Split(" ").Length == 3 && input.Contains("clear") == false)
            {
                return true;
            }
            else return false;
        }

        public bool IfShowArgument(string input)
        {
            if (input.Contains("arg ") && input.Split(" ").Length == 2)
            {
                return true;
            }
            else return false;
        }

        public bool IfShowAllArguments(string input)
        {
            if (input.Contains("args show") && input.Split(" ").Length == 2)
            {
                return true;
            }
            else return false;
        }

        public bool IfShowArgumentFromName(string input, IDictionary<string, Argument> dictArgs)
        {
            if (dictArgs.Keys.Any(Key => input.Contains(Key)) && input.Split(' ').Length == 1)
            {
                return true;
            }
            else return false;
        }

        public bool IfCalc(string input)
        {
            if (input.Contains("calc") || input.Split(' ').FirstOrDefault() == "=")
            {
                return true;
            }
            else return false;
        }

        public bool IfDropAllArguments(string input)
        {
            if (input.Contains("args clear") && input.Split(' ').Length == 2)
            {
                return true;
            }
            else return false;
        }

        public bool IfDropOneArgument(string input)
        {
            if (input.Contains("arg") && input.Contains("clear") && input.Split(' ').Length == 3)
            {
                return true;
            }
            else return false;
        }

        public bool IfClear(string input)
        {
            if (input.Contains("clear") && input.Split(' ').Length == 1)
            {
                return true;
            }
            else return false;
        }

        public bool IfHelp(string input)
        {
            if (input.Contains("help") && input.Split(' ').Length == 1)
            {
                return true;
            }
            else return false;
        }
    }
}
