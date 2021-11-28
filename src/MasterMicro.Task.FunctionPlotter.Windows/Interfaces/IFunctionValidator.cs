using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MasterMicro.Task.FunctionPlotter.Windows.Globals.GlobalConfigs;

namespace MasterMicro.Task.FunctionPlotter.Windows.Interfaces
{
    public interface IFunctionValidator
    {
        /// <summary>
        /// validate the F(x) string function 
        /// valid function should be of one variable and has the basic math operations [+,-,*,/,^] 
        /// </summary>
        /// <param name="fx"> the function string </param>
        /// <returns> validation type reprsents the error type or valid state </returns>
        FunctionValidationType ValidFunction(string fx);
    }
}
