using NUnit.Framework;
using Kalkulator_konsola;
using System;
using System.IO;
using CLI_Calculator;

namespace CLI_CalculatorTests
{
    public class Tests
    {
        Calculator c1 = new Calculator(new Conditions(), new OutputInput());

        [TestCase ("arg x 5","arg x","x = 5\n")]
        [TestCase ("arg y 70","arg y","y = 70\n")]
        [TestCase ("arg a -9","arg a","a = -9\n")]
        [TestCase ("arg z 5.2", "arg z","z = 5.2\n")]
        public void Adding_Arguments(string input, string input2, string expectedValue)
        {
            //arrange
            var stringWriter = new StringWriter();

            //act
            c1.SetInput(input);
            c1.Evaluate();

            Console.SetOut(stringWriter);
            c1.SetInput(input2);
            c1.Evaluate();

            //assert
            var output = stringWriter.ToString();
            Assert.AreEqual(expectedValue, output);
        }
        [TestCase("calc 5+10", "15\n")]
        [TestCase("= 5+10", "15\n")]
        public void Calculating_Equations(string input, string expectedValue)
        {
            //arrange
            var stringWriter = new StringWriter();

            //act
            c1.SetInput(input);
            Console.SetOut(stringWriter);
            c1.Evaluate();

            //asert
            var output = stringWriter.ToString();
            Assert.AreEqual(expectedValue, output);
        }
        [TestCase("arg x 25", "arg y 30", "args clear")]
        public void Dropping_All_Arguments(string input, string input2, string input3)
        {
            //act
            c1.SetInput(input);
            c1.Evaluate();
            c1.SetInput(input2);
            c1.Evaluate();
            c1.SetInput(input3);
            c1.Evaluate();

            //assert
            Assert.IsTrue(c1.GetDictArgs().Count == 0);
        }
    }
}
