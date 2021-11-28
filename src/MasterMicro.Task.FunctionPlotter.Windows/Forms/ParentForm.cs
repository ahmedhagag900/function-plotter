using MasterMicro.Task.FunctionPlotter.Windows.Exceptions;
using MasterMicro.Task.FunctionPlotter.Windows.Interfaces;
using MasterMicro.Task.FunctionPlotter.Windows.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MasterMicro.Task.FunctionPlotter.Windows
{
    public partial class ParentForm : Form
    {
        private readonly IFunctionSolver _functionSolver;
        public ParentForm()
        {
            InitializeComponent();
            _functionSolver = ServiceFactory.CreateFunctionSolverService();
        }

        private void btnPlot_Click(object sender, EventArgs e)
        {
            var function = txtFx.Text;
            if (!ValidateMinAndMaxValue()) return;

            var minVal = double.Parse(txtMinVal.Text);
            var maxVal = double.Parse(txtMaxVal.Text);
            double[] Xs = new double[(int)maxVal - (int)minVal + 1];
            double[] Ys = new double[(int)maxVal - (int)minVal + 1];
            try
            {
                for (int i = (int)minVal, idx = 0; i <= (int)maxVal; ++i, ++idx)
                {
                    Xs[idx] = i;
                    Ys[idx] = _functionSolver.SolveFunction(function, i);
                }
            }catch (InvalidFunctionException ex)
            {
                MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }catch(Exception ex)
            {
                MessageBox.Show("Error while calcuating the function solution: \n" + ex.Message , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            pltFx.Plot.AxisAuto();
            pltFx.Plot.Clear();
            pltFx.Plot.AddScatter(Xs, Ys);
            pltFx.Refresh();
        }

        private bool ValidateMinAndMaxValue()
        {
            if(string.IsNullOrEmpty(txtMinVal.Text)||string.IsNullOrEmpty(txtMaxVal.Text))
            {
                MessageBox.Show("Min and Max value should not be empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            double tryVal = -1;
            bool minTry = double.TryParse(txtMinVal.Text, out tryVal);
            bool maxTry = double.TryParse(txtMaxVal.Text, out tryVal);
            if(!(minTry&&maxTry))
            {
                MessageBox.Show("Invalid format of Min or Max value check it again", "Warnging", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}
