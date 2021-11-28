using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMicro.Task.FunctionPlotter.Windows.Interfaces
{
    public interface IFunctionSolver
    {
        /// <summary>
        /// Solves a parsed Function
        /// </summary>
        /// <param name="fx">the function to solve </param>
        /// <param name="x">the variable value to compensate </param>
        /// <returns>f(x),y the solution of the function at point (x) on X-axis</returns>
        double SolveFunction(string fx,double x);
    }
}
