
namespace MasterMicro.Task.FunctionPlotter.Windows
{
    partial class ParentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pltFx = new ScottPlot.FormsPlot();
            this.txtFx = new System.Windows.Forms.TextBox();
            this.txtMinVal = new System.Windows.Forms.TextBox();
            this.txtMaxVal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPlot = new System.Windows.Forms.Button();
            this.btnExportPlot = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pltFx
            // 
            this.pltFx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pltFx.AutoScroll = true;
            this.pltFx.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pltFx.BackColor = System.Drawing.Color.Transparent;
            this.pltFx.Location = new System.Drawing.Point(12, 116);
            this.pltFx.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pltFx.Name = "pltFx";
            this.pltFx.Size = new System.Drawing.Size(962, 417);
            this.pltFx.TabIndex = 0;
            // 
            // txtFx
            // 
            this.txtFx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtFx.Location = new System.Drawing.Point(106, 53);
            this.txtFx.Name = "txtFx";
            this.txtFx.Size = new System.Drawing.Size(188, 24);
            this.txtFx.TabIndex = 1;
            // 
            // txtMinVal
            // 
            this.txtMinVal.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtMinVal.Location = new System.Drawing.Point(496, 38);
            this.txtMinVal.Name = "txtMinVal";
            this.txtMinVal.Size = new System.Drawing.Size(100, 24);
            this.txtMinVal.TabIndex = 2;
            // 
            // txtMaxVal
            // 
            this.txtMaxVal.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtMaxVal.Location = new System.Drawing.Point(496, 68);
            this.txtMaxVal.Name = "txtMaxVal";
            this.txtMaxVal.Size = new System.Drawing.Size(100, 24);
            this.txtMaxVal.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "F(x) : ";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(425, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Min Value";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(425, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "MaxValue";
            // 
            // btnPlot
            // 
            this.btnPlot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlot.Location = new System.Drawing.Point(789, 46);
            this.btnPlot.Name = "btnPlot";
            this.btnPlot.Size = new System.Drawing.Size(166, 36);
            this.btnPlot.TabIndex = 7;
            this.btnPlot.Text = "Plot F(x) ";
            this.btnPlot.UseVisualStyleBackColor = true;
            this.btnPlot.Click += new System.EventHandler(this.btnPlot_Click);
            // 
            // btnExportPlot
            // 
            this.btnExportPlot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportPlot.Location = new System.Drawing.Point(789, 47);
            this.btnExportPlot.Name = "btnExportPlot";
            this.btnExportPlot.Size = new System.Drawing.Size(166, 36);
            this.btnExportPlot.TabIndex = 8;
            this.btnExportPlot.Text = "Export Plot as Image";
            this.btnExportPlot.UseVisualStyleBackColor = true;
            this.btnExportPlot.Visible = false;
            // 
            // ParentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 546);
            this.Controls.Add(this.btnPlot);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMaxVal);
            this.Controls.Add(this.txtMinVal);
            this.Controls.Add(this.txtFx);
            this.Controls.Add(this.pltFx);
            this.Controls.Add(this.btnExportPlot);
            this.Name = "ParentForm";
            this.Text = "Function Plotter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ScottPlot.FormsPlot pltFx;
        private System.Windows.Forms.TextBox txtFx;
        private System.Windows.Forms.TextBox txtMinVal;
        private System.Windows.Forms.TextBox txtMaxVal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPlot;
        private System.Windows.Forms.Button btnExportPlot;
    }
}

