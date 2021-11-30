using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMicro.Task.FunctionPlotter.Windows.Globals
{
    public static class GlobalConfigs
    {
        public enum FunctionValidationType
        {
            InvalidMultiVariableFunction =1,
            InvalidFunctionFormat=2,
            InvalidEmptyFunction=3,
            ValidFunction=4,
        }
        public static bool AreNumbers(char first,char second)
        {
            return (first >= '0' && first <= '9' && second >= '0' && second <= '9');
        }
        public static bool AreAlphapets(char first, char second)
        {
            return (first >= 'a' && first <= 'z' && second >= 'a' && second <= 'z')||(first >= 'A' && first <= 'Z' && second >= 'A' && second <= 'Z');
        }
    }
}
