using MasterMicro.Task.FunctionPlotter.Windows;
using MasterMicro.Task.FunctionPlotter.Windows.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MasterMicro.Task.FunctionPlotter.Test
{
    public class FunctionParserTests
    {
        private readonly IFunctionParser _functionParser;
        public FunctionParserTests()
        {
            _functionParser = ServiceFactory.CreateFunctionParserService();
        }

        [Theory]
        [InlineData("xx2","x*x*2")]
        [InlineData("x5", "x*5")]
        [InlineData("x + 5","x+5")]
        public void ShouldReturnValidParsedFunction(string function,string expectedParsedFunction)
        {
            var actual = _functionParser.ParesFunction(function);

            Assert.Equal(expectedParsedFunction, actual);
        }
    }
}
