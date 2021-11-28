using MasterMicro.Task.FunctionPlotter.Windows.Interfaces;
using MasterMicro.Task.FunctionPlotter.Windows.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMicro.Task.FunctionPlotter.Windows
{
    public class ServiceFactory
    {
        public static IFunctionValidator CreateFunctionValidatorService()
        {
            return new FunctionValidatorService();
        }
        public static IFunctionParser CreateFunctionParserService()
        {
            return new FunctionParserService(CreateFunctionValidatorService());
        }
        public static IFunctionSolver CreateFunctionSolverService()
        {
            return new FunctionSolverService(CreateFunctionParserService());
        }
    }
}
