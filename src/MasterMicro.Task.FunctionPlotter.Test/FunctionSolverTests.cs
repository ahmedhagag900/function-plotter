using MasterMicro.Task.FunctionPlotter.Windows;
using MasterMicro.Task.FunctionPlotter.Windows.Exceptions;
using MasterMicro.Task.FunctionPlotter.Windows.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MasterMicro.Task.FunctionPlotter.Test
{
    public class FunctionSolverTests
    {
        private readonly IFunctionSolver _functionSolver;
        public FunctionSolverTests()
        {
            _functionSolver = ServiceFactory.CreateFunctionSolverService();
        }

        //[Fact]
        [Theory()]
        [InlineData("x^2+5x-10",3,14)]
        [InlineData("x^2+5x-10", 5, 40)]
        [InlineData("xx+5*x-10", 5, 40)]
        public void ShoulReturnFunctionSolutionInX(string function,double x,double fxSol)
        {
            
            var expected = fxSol;
            var actual = _functionSolver.SolveFunction(function, x);

            Assert.Equal(expected, actual);
        }
        [Theory()]
        [InlineData("xx+5*x-10+", 5)]
        [InlineData("xx+5*x--10+", 5)]
        [InlineData("xx+5*xy-10+", 5)]
        public void ShouldThrowInvalidFunctionExcption(string function,double x)
        {
            Assert.Throws<InvalidFunctionException>(() => _functionSolver.SolveFunction(function, x));
        }
    }
}
