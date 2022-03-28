using CLI_Calculator;

namespace Kalkulator_konsola
{
    class Program
    {
        static void Main(string[] args)
        {

            Calculator calc = new Calculator(new Conditions(), new OutputInput());
            while (true)
            {
                calc.SetInput(calc.ReadInput());
                if (calc.GetInput() == "quit")
                {
                    break;
                }
                else
                {
                    calc.Evaluate();
                }
            }
        }
    }
}