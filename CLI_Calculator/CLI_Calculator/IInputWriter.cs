using System;
namespace CLI_Calculator
{
    public interface IInputWriter
    {
        public void WriteOutputWithBreakRow(string value);
        public void WriteOutputWithoutBreakRow(string value);
    }
}
