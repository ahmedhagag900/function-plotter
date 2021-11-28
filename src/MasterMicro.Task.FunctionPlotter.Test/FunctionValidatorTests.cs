using MasterMicro.Task.FunctionPlotter.Windows;
using MasterMicro.Task.FunctionPlotter.Windows.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using static MasterMicro.Task.FunctionPlotter.Windows.Globals.GlobalConfigs;

namespace MasterMicro.Task.FunctionPlotter.Test
{
    public class FunctionValidatorTests
    {
        private readonly IFunctionValidator _functionValidator;

        public FunctionValidatorTests()
        {
            _functionValidator = ServiceFactory.CreateFunctionValidatorService();
        }

        [Fact]
        public void ShouldReturnInvalidEmptyFunction()
        {
            var actual = _functionValidator.ValidFunction("");

            Assert.Equal(FunctionValidationType.InvalidEmptyFunction, actual);
        }

        [Theory]
        [InlineData("xy+5")]
        [InlineData("xy+5+a^3")]
        [InlineData("xx+5*a^2")]
        [InlineData("ab")]
        public void ShouldReturnInvalidMultiVariableFunction(string function)
        {
            var actual = _functionValidator.ValidFunction(function);

            Assert.Equal(FunctionValidationType.InvalidMultiVariableFunction, actual);
        }
        [Theory]
        [InlineData("+")]
        [InlineData("-5+")]
        [InlineData("-5+x&")]
        public void ShouldReturnInvalidFormatFunction(string function)
        {
            var actual = _functionValidator.ValidFunction(function);

            Assert.Equal(FunctionValidationType.InvalidFunctionFormat, actual);
        }

        [Theory]


        [InlineData("x+8")]
        [InlineData("x+8+x^2")]
        [InlineData("x+8+xx")]
        [InlineData("x+8x-51")]
        public void ShouldReturnValidFunctionState(string function)
        {
            var actual = _functionValidator.ValidFunction(function);

            Assert.Equal(FunctionValidationType.ValidFunction, actual);
        }

    }
}
