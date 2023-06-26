namespace CredirCalculator
{
    partial class Conclusion
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
            this.dtg_Main = new System.Windows.Forms.DataGridView();
            this.Month = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Summ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OsnDolg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Proc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remains = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_Main)).BeginInit();
            this.SuspendLayout();
            // 
            // dtg_Main
            // 
            this.dtg_Main.AllowUserToAddRows = false;
            this.dtg_Main.AllowUserToDeleteRows = false;
            this.dtg_Main.AllowUserToResizeColumns = false;
            this.dtg_Main.AllowUserToResizeRows = false;
            this.dtg_Main.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtg_Main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_Main.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Month,
            this.Summ,
            this.OsnDolg,
            this.Proc,
            this.Remains});
            this.dtg_Main.Location = new System.Drawing.Point(2, 1);
            this.dtg_Main.Name = "dtg_Main";
            this.dtg_Main.ReadOnly = true;
            this.dtg_Main.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtg_Main.Size = new System.Drawing.Size(701, 359);
            this.dtg_Main.TabIndex = 0;
            // 
            // Month
            // 
            this.Month.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Month.FillWeight = 10F;
            this.Month.HeaderText = "Month";
            this.Month.Name = "Month";
            this.Month.ReadOnly = true;
            // 
            // Summ
            // 
            this.Summ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Summ.FillWeight = 23F;
            this.Summ.HeaderText = "Summ";
            this.Summ.Name = "Summ";
            this.Summ.ReadOnly = true;
            // 
            // OsnDolg
            // 
            this.OsnDolg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.OsnDolg.FillWeight = 23F;
            this.OsnDolg.HeaderText = "Main Dolg";
            this.OsnDolg.Name = "OsnDolg";
            this.OsnDolg.ReadOnly = true;
            // 
            // Proc
            // 
            this.Proc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Proc.FillWeight = 23F;
            this.Proc.HeaderText = "Dolg proc";
            this.Proc.Name = "Proc";
            this.Proc.ReadOnly = true;
            // 
            // Remains
            // 
            this.Remains.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Remains.FillWeight = 23F;
            this.Remains.HeaderText = "Remains";
            this.Remains.Name = "Remains";
            this.Remains.ReadOnly = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(274, 373);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "Export";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Conclusion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 420);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtg_Main);
            this.Name = "Conclusion";
            this.Text = "Conclusion";
            ((System.ComponentModel.ISupportInitialize)(this.dtg_Main)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtg_Main;
        private System.Windows.Forms.DataGridViewTextBoxColumn Month;
        private System.Windows.Forms.DataGridViewTextBoxColumn Summ;
        private System.Windows.Forms.DataGridViewTextBoxColumn OsnDolg;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remains;
        private System.Windows.Forms.Button button1;
    }
}