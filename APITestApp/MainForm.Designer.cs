namespace APITestApp
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnRun = new System.Windows.Forms.Button();
            this.dgvSteps = new System.Windows.Forms.DataGridView();
            this.btnAddStep = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnDeleteStep = new System.Windows.Forms.Button();
            this.tvwScripts = new System.Windows.Forms.TreeView();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtScriptName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSteps)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRun
            // 
            this.btnRun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(85)))), ((int)(((byte)(255)))));
            this.btnRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRun.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnRun.Location = new System.Drawing.Point(439, 442);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(227, 36);
            this.btnRun.TabIndex = 0;
            this.btnRun.Text = "Run API Script";
            this.btnRun.UseVisualStyleBackColor = false;
            this.btnRun.EnabledChanged += new System.EventHandler(this.btn_EnabledChanged);
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // dgvSteps
            // 
            this.dgvSteps.AllowUserToAddRows = false;
            this.dgvSteps.AllowUserToResizeRows = false;
            this.dgvSteps.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvSteps.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvSteps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSteps.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvSteps.EnableHeadersVisualStyles = false;
            this.dgvSteps.Location = new System.Drawing.Point(12, 9);
            this.dgvSteps.MultiSelect = false;
            this.dgvSteps.Name = "dgvSteps";
            this.dgvSteps.RowHeadersVisible = false;
            this.dgvSteps.RowHeadersWidth = 62;
            this.dgvSteps.RowTemplate.Height = 20;
            this.dgvSteps.Size = new System.Drawing.Size(642, 367);
            this.dgvSteps.TabIndex = 3;
            this.dgvSteps.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSteps_CellClick);
            this.dgvSteps.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSteps_CellContentClick);
            this.dgvSteps.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSteps_CellEnter);
            this.dgvSteps.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvSteps_CurrentCellDirtyStateChanged);
            this.dgvSteps.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvSteps_DataError);
            // 
            // btnAddStep
            // 
            this.btnAddStep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(85)))), ((int)(((byte)(255)))));
            this.btnAddStep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddStep.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnAddStep.Location = new System.Drawing.Point(12, 442);
            this.btnAddStep.Name = "btnAddStep";
            this.btnAddStep.Size = new System.Drawing.Size(129, 36);
            this.btnAddStep.TabIndex = 4;
            this.btnAddStep.Text = "Add Step";
            this.btnAddStep.UseVisualStyleBackColor = false;
            this.btnAddStep.EnabledChanged += new System.EventHandler(this.btn_EnabledChanged);
            this.btnAddStep.Click += new System.EventHandler(this.btnAddStep_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(85)))), ((int)(((byte)(255)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.Location = new System.Drawing.Point(282, 442);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(129, 36);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save Script";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.EnabledChanged += new System.EventHandler(this.btn_EnabledChanged);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(85)))), ((int)(((byte)(255)))));
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnLoad.Location = new System.Drawing.Point(110, 512);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(88, 36);
            this.btnLoad.TabIndex = 8;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.EnabledChanged += new System.EventHandler(this.btn_EnabledChanged);
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnDeleteStep
            // 
            this.btnDeleteStep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(85)))), ((int)(((byte)(255)))));
            this.btnDeleteStep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteStep.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnDeleteStep.Location = new System.Drawing.Point(147, 442);
            this.btnDeleteStep.Name = "btnDeleteStep";
            this.btnDeleteStep.Size = new System.Drawing.Size(129, 36);
            this.btnDeleteStep.TabIndex = 9;
            this.btnDeleteStep.Text = "Delete Step";
            this.btnDeleteStep.UseVisualStyleBackColor = false;
            this.btnDeleteStep.EnabledChanged += new System.EventHandler(this.btn_EnabledChanged);
            this.btnDeleteStep.Click += new System.EventHandler(this.btnDeleteStep_Click);
            // 
            // tvwScripts
            // 
            this.tvwScripts.Location = new System.Drawing.Point(12, 9);
            this.tvwScripts.Name = "tvwScripts";
            this.tvwScripts.Size = new System.Drawing.Size(250, 431);
            this.tvwScripts.TabIndex = 10;
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(85)))), ((int)(((byte)(255)))));
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnNew.Location = new System.Drawing.Point(16, 512);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(88, 36);
            this.btnNew.TabIndex = 11;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.EnabledChanged += new System.EventHandler(this.btn_EnabledChanged);
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(85)))), ((int)(((byte)(255)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnDelete.Location = new System.Drawing.Point(204, 512);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(88, 36);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.EnabledChanged += new System.EventHandler(this.btn_EnabledChanged);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtScriptName
            // 
            this.txtScriptName.Location = new System.Drawing.Point(165, 11);
            this.txtScriptName.Name = "txtScriptName";
            this.txtScriptName.Size = new System.Drawing.Size(489, 26);
            this.txtScriptName.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(6, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 23);
            this.label9.TabIndex = 17;
            this.label9.Text = "Scripts";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.tvwScripts);
            this.panel1.Location = new System.Drawing.Point(16, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(276, 453);
            this.panel1.TabIndex = 20;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.label9);
            this.panel2.Location = new System.Drawing.Point(16, 9);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(82, 44);
            this.panel2.TabIndex = 21;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(77)))), ((int)(((byte)(149)))));
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.btnNew);
            this.panel3.Controls.Add(this.btnLoad);
            this.panel3.Controls.Add(this.btnDelete);
            this.panel3.Location = new System.Drawing.Point(17, 122);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(312, 560);
            this.panel3.TabIndex = 22;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.txtScriptName);
            this.panel4.Location = new System.Drawing.Point(12, 10);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(669, 44);
            this.panel4.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(8, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 23);
            this.label2.TabIndex = 17;
            this.label2.Text = "Script Name";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel5.Controls.Add(this.dgvSteps);
            this.panel5.Location = new System.Drawing.Point(12, 44);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(669, 389);
            this.panel5.TabIndex = 23;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel6.Controls.Add(this.label3);
            this.panel6.Location = new System.Drawing.Point(12, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(135, 44);
            this.panel6.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(6, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 23);
            this.label3.TabIndex = 17;
            this.label3.Text = "Script Steps";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(77)))), ((int)(((byte)(149)))));
            this.panel8.Controls.Add(this.panel4);
            this.panel8.Location = new System.Drawing.Point(335, 122);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(700, 64);
            this.panel8.TabIndex = 25;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(77)))), ((int)(((byte)(149)))));
            this.panel9.Controls.Add(this.panel6);
            this.panel9.Controls.Add(this.panel5);
            this.panel9.Controls.Add(this.btnSave);
            this.panel9.Controls.Add(this.btnDeleteStep);
            this.panel9.Controls.Add(this.btnRun);
            this.panel9.Controls.Add(this.btnAddStep);
            this.panel9.Location = new System.Drawing.Point(335, 192);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(700, 490);
            this.panel9.TabIndex = 26;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(85)))), ((int)(((byte)(255)))));
            this.panel10.Controls.Add(this.label10);
            this.panel10.Location = new System.Drawing.Point(-2, -1);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1067, 117);
            this.panel10.TabIndex = 27;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Britannic Bold", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label10.Location = new System.Drawing.Point(25, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(259, 58);
            this.label10.TabIndex = 3;
            this.label10.Text = "API Tester";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1051, 693);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dgvSteps)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.DataGridView dgvSteps;
        private System.Windows.Forms.Button btnAddStep;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnDeleteStep;
        private System.Windows.Forms.TreeView tvwScripts;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtScriptName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label10;
    }
}

