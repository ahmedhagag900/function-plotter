using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterMicro.Task.FunctionPlotter.Windows.Exceptions;

namespace MasterMicro.Task.FunctionPlotter.Windows.Interfaces
{
    public interface IFunctionParser
    {
       
        /// <summary>
        /// Parese the inputed functions 
        /// function should be of one variable and has the basic math operations [+,-,*,/,^] 
        /// </summary>
        /// <param name="fx">the function to pares</param>
        /// <returns>string token represents the paresed function </returns>
        /// <exception cref="InvalidFunctionException">the input function is invalid </exception>
        string ParesFunction(string fx);

    }
}
