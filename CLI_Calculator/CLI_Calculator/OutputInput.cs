using System;
namespace CLI_Calculator
{
    public class OutputInput : IInputCleaner, IInputReader, IInputWriter
    {
        public OutputInput()
        {
        }

        public void ClearOutput()
        {
            Console.Clear();
        }

        public void WriteOutputWithBreakRow(string value)
        {
            Console.WriteLine(value);
        }
        public void WriteOutputWithoutBreakRow(string value)
        {
            Console.Write(value);
        }

        public string ReadInput()
        {
            return Console.ReadLine();
        }
    }
}
