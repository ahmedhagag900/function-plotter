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
    public class FunctionValidatorService : IFunctionValidator
    {
        private readonly char[] _operations;
        public FunctionValidatorService()
        {
            _operations = new char[]
            {
                '*','/','+','-','^'
            };
        }
        public FunctionValidationType ValidFunction(string fx)
        {
            if (string.IsNullOrEmpty(fx)) return FunctionValidationType.InvalidEmptyFunction;
            if (!IsValidFormat(fx.Trim())) return FunctionValidationType.InvalidFunctionFormat;
            if (IsMultiVariableFunction(fx)) return FunctionValidationType.InvalidMultiVariableFunction;
            return FunctionValidationType.ValidFunction;
        }
        public bool IsMultiVariableFunction(string fx)
        {
            var varCount = fx.Where(x => (x>='a'&&x<='z')||(x>='A'&&x<='Z')).Distinct().Count();
            return varCount > 1;
        }
        public bool IsValidFormat(string fx)
        {
            var regex = new Regex(@"(\-?[a-zA-Z0-9]+[+\-\/*\^]?)+([a-zA-Z0-9]$)");
            var ss = regex.IsMatch(fx);
            return regex.IsMatch(fx);
        }
    }
}
