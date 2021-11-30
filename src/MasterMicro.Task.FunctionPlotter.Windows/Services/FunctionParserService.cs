using MasterMicro.Task.FunctionPlotter.Windows.Exceptions;
using MasterMicro.Task.FunctionPlotter.Windows.Globals;
using MasterMicro.Task.FunctionPlotter.Windows.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static MasterMicro.Task.FunctionPlotter.Windows.Globals.GlobalConfigs;

namespace MasterMicro.Task.FunctionPlotter.Windows.Services
{
    public class FunctionParserService : IFunctionParser
    {
        private char[] _operations;
        private readonly IFunctionValidator _functionValidator;
        public FunctionParserService(IFunctionValidator functionValidator)
        {
            _functionValidator = functionValidator ?? throw new ArgumentNullException(nameof(functionValidator));
            _operations = new char[] { '*', '/', '+', '-', '^' };
        }
        public string ParesFunction(string fx)
        {
            //remove empty spaces from the function
            fx = new string(fx.Where(x => x != ' ').ToArray());
            
            //validate the function 
            var validateFunctionState = _functionValidator.ValidFunction(fx);
            if (validateFunctionState != FunctionValidationType.ValidFunction)
                throw new InvalidFunctionException(validateFunctionState.ToString(), new ArgumentException());
           
            
            fx = NormalizeFunctionMuliplications(fx);
            return fx;
        }

        /// <summary>
        /// Normalize the function token to multiplication opration
        /// </summary>
        /// <param name="fx">string token represents the function </param>
        /// <returns>normalized function token string </returns>
        private string NormalizeFunctionMuliplications(string fx)
        {
            StringBuilder res = new StringBuilder();
            res.Append(fx[0]);
            char prev = fx[0];
            for(int i=1;i<fx.Length ;++i)
            {
                //check the characters are not in the same group [numbers,alphpets] and not an operation character
                //then there is a multiplication operation so construct a multipliction token ex: [5x]-> [5*x]
                if (!(AreNumbers(fx[i], prev) || 
                    _operations.Contains(fx[i]) ||
                    _operations.Contains(prev)))
                {
                    res.Append('*');
                }
                res.Append(fx[i]);
                prev = fx[i];
            }

            return res.ToString();
        }
    }
}
