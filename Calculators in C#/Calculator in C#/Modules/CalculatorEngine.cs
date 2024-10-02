using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_in_C_.Modules
{
    internal class CalculatorEngine
    {
        private readonly Grid grid;
        private readonly Logic logic;

        internal CalculatorEngine()
        {
            this.grid = new Grid();
            this.logic = new Logic();
        }
        internal void RunApp()
        {
            while (true)
            {
                grid.getIntro();

                string input = grid.getInput();

                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    grid.goodByeDisply();
                    break;
                }
                try
                {
                    double result = logic.evaluateExpression(input);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
