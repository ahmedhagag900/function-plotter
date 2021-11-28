using MasterMicro.Task.FunctionPlotter.Windows.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MasterMicro.Task.FunctionPlotter.Windows.Services
{
    public class FunctionSolverService : IFunctionSolver
    {
        private readonly IFunctionParser _functionParser;
        private readonly char[] _operations;
        public FunctionSolverService(IFunctionParser functionParser)
        {
            _operations = new char[]{'*','/','+','-','^'};
            _functionParser = functionParser ?? throw new ArgumentNullException(nameof(functionParser));
        }

        /// <summary>
        /// Solve the function of one variabel in (x)
        /// </summary>
        /// <param name="fx">string token represents the function to solve </param>
        /// <param name="x">the value of the function variable </param>
        /// <returns>function solution in (x)</returns>
        public double SolveFunction(string fx, double x)
        {
            var parsedFunction = _functionParser.ParesFunction(fx);
            var functionVariableChar = parsedFunction.Where(ch => (ch >= 'a' && x <= 'z') || (ch >= 'A' && ch <= 'Z')).FirstOrDefault();

            parsedFunction = EvalutePowerTokens(parsedFunction, functionVariableChar, x);
            parsedFunction = CompensateFunctionVariable(parsedFunction, functionVariableChar, x);
            //to make the evaluater calculate it as double
            
            //evalute the paresd function with the dataTable evaluater and get the function solution in (x) 
            DataTable expressionEvalouator = new DataTable();
            var solValue = expressionEvalouator.Compute(parsedFunction, string.Empty).ToString();
            double solution = double.Parse(solValue);
            
            return solution;

        }

        /// <summary>
        /// compensate and evaluate the power tokens [oper1^oper2] with the value of this power
        /// ex: 2^5 ==> 32 
        /// ex: x^2 for(x=2) ==> 4 
        /// </summary>
        /// <param name="parsedFunction"></param>
        /// <param name="functionVariable"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        private string EvalutePowerTokens(string parsedFunction,char functionVariable,double x)
        {
            StringBuilder evaluationResult = new StringBuilder();
            StringBuilder firstOperand = new StringBuilder();
            for (int i = 0; i < parsedFunction.Length; ++i)
            {
                if (_operations.Contains(parsedFunction[i]))
                {
                    if (parsedFunction[i] == '^')
                    {
                        StringBuilder secondOperand = new StringBuilder();
                        int j = i + 1;
                        //get second operation operand
                        for (; j < parsedFunction.Length; ++j)
                        {
                            if (!_operations.Contains(parsedFunction[j])) secondOperand.Append(parsedFunction[j]);
                            else break;
                        }

                        //check if the opration operands are the function variable and replace it with the value
                        if (firstOperand.ToString() == functionVariable.ToString()) firstOperand = new StringBuilder(x.ToString());
                        if (secondOperand.ToString() == functionVariable.ToString()) secondOperand = new StringBuilder(x.ToString());

                        //apply the power operation on the operands 
                        var operationResult = Math.Pow(double.Parse(firstOperand.ToString()), double.Parse(secondOperand.ToString()));

                        //get the old equation positions to Compensate it with the new value
                        int startIdxToDelete = evaluationResult.Length - 1;
                        for (; startIdxToDelete >= 0; --startIdxToDelete)
                        {
                            if (_operations.Contains(evaluationResult[startIdxToDelete])) break;
                        }

                        evaluationResult = evaluationResult.Remove(startIdxToDelete + 1, evaluationResult.Length - (startIdxToDelete + 1));
                        evaluationResult.Append(operationResult.ToString());

                        //jump to the next token and reinitialize the first operand
                        i = j - 1;
                        firstOperand = new StringBuilder();
                        continue;
                    }
                    //reinitialize the first operand if there was and opration character
                    firstOperand = new StringBuilder();
                }
                else 
                { 
                    firstOperand.Append(parsedFunction[i]);
                }
                evaluationResult.Append(parsedFunction[i]);
            }

            return evaluationResult.ToString();
        }

        /// <summary>
        /// Compensate the function variable with the value of (x)
        /// </summary>
        /// <param name="parsedFunction">function string </param>
        /// <param name="functionVariable">function variable character</param>
        /// <param name="x">the vale of the variable</param>
        /// <returns>token string represents the compensate function with (x) value</returns>
        private string CompensateFunctionVariable(string parsedFunction, char functionVariable, double x)
        {
            StringBuilder compensatedFunction = new StringBuilder();
            for (int i = 0; i < parsedFunction.Length; ++i)
            {
                if (parsedFunction[i]==functionVariable)
                {
                    compensatedFunction.Append(x.ToString());
                    continue;
                }
                compensatedFunction.Append(parsedFunction[i]);
            }

            return compensatedFunction.ToString();
        }
    }
}
