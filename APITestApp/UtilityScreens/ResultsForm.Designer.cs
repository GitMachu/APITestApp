namespace APITestApp.UtilityScreens
{
    partial class ResultsForm
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblScriptName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.StepNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StepScreen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StepControl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StepStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(77)))), ((int)(((byte)(149)))));
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Location = new System.Drawing.Point(14, 84);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(773, 516);
            this.panel3.TabIndex = 28;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.label9);
            this.panel2.Location = new System.Drawing.Point(16, 9);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(92, 44);
            this.panel2.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(6, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 23);
            this.label9.TabIndex = 17;
            this.label9.Text = "Results";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.dgvResults);
            this.panel1.Location = new System.Drawing.Point(16, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(744, 453);
            this.panel1.TabIndex = 20;
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.AllowUserToResizeColumns = false;
            this.dgvResults.AllowUserToResizeRows = false;
            this.dgvResults.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvResults.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StepNumber,
            this.StepScreen,
            this.StepControl,
            this.StepStatus});
            this.dgvResults.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvResults.EnableHeadersVisualStyles = false;
            this.dgvResults.Location = new System.Drawing.Point(19, 9);
            this.dgvResults.MultiSelect = false;
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.RowHeadersVisible = false;
            this.dgvResults.RowHeadersWidth = 62;
            this.dgvResults.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvResults.RowTemplate.Height = 20;
            this.dgvResults.Size = new System.Drawing.Size(707, 422);
            this.dgvResults.TabIndex = 4;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(77)))), ((int)(((byte)(149)))));
            this.panel5.Controls.Add(this.panel4);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Location = new System.Drawing.Point(14, 12);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(773, 64);
            this.panel5.TabIndex = 29;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel4.Controls.Add(this.lblStatus);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(393, 10);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(367, 44);
            this.panel4.TabIndex = 22;
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Black;
            this.lblStatus.Location = new System.Drawing.Point(96, 13);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(123, 26);
            this.lblStatus.TabIndex = 17;
            this.lblStatus.Text = "Step 1/10";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(8, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 23);
            this.label2.TabIndex = 17;
            this.label2.Text = "Status:";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel6.Controls.Add(this.lblScriptName);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Location = new System.Drawing.Point(12, 10);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(375, 44);
            this.panel6.TabIndex = 22;
            // 
            // lblScriptName
            // 
            this.lblScriptName.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScriptName.ForeColor = System.Drawing.Color.Black;
            this.lblScriptName.Location = new System.Drawing.Point(149, 12);
            this.lblScriptName.Name = "lblScriptName";
            this.lblScriptName.Size = new System.Drawing.Size(177, 26);
            this.lblScriptName.TabIndex = 17;
            this.lblScriptName.Text = "Step 1/10";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(8, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 23);
            this.label3.TabIndex = 17;
            this.label3.Text = "Script Name:";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(85)))), ((int)(((byte)(255)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnClose.Location = new System.Drawing.Point(334, 610);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 36);
            this.btnClose.TabIndex = 30;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // StepNumber
            // 
            this.StepNumber.HeaderText = "#";
            this.StepNumber.MinimumWidth = 8;
            this.StepNumber.Name = "StepNumber";
            this.StepNumber.ReadOnly = true;
            this.StepNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.StepNumber.Width = 40;
            // 
            // StepScreen
            // 
            this.StepScreen.HeaderText = "Request Type";
            this.StepScreen.MinimumWidth = 8;
            this.StepScreen.Name = "StepScreen";
            this.StepScreen.ReadOnly = true;
            this.StepScreen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.StepScreen.Width = 120;
            // 
            // StepControl
            // 
            this.StepControl.HeaderText = "Parameters";
            this.StepControl.MinimumWidth = 80;
            this.StepControl.Name = "StepControl";
            this.StepControl.ReadOnly = true;
            this.StepControl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.StepControl.Width = 120;
            // 
            // StepStatus
            // 
            this.StepStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StepStatus.HeaderText = "Status";
            this.StepStatus.MinimumWidth = 154;
            this.StepStatus.Name = "StepStatus";
            this.StepStatus.ReadOnly = true;
            this.StepStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 658);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ResultsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Results";
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblScriptName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn StepNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn StepScreen;
        private System.Windows.Forms.DataGridViewTextBoxColumn StepControl;
        private System.Windows.Forms.DataGridViewTextBoxColumn StepStatus;
    }
}