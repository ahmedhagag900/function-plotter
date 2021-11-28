using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMicro.Task.FunctionPlotter.Windows.Exceptions
{
    public class InvalidFunctionException:Exception
    {
        public InvalidFunctionException():base()
        { }
        public InvalidFunctionException(string message) : base(message)
        { }
        public InvalidFunctionException(string message,Exception innerException) : base(message,innerException)
        { }
    }

}
