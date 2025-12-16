namespace NPCDialogueManager.App
{
    partial class ReportStatusForm
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
            this.cboNPC = new System.Windows.Forms.ComboBox();
            this.dgvSessions = new System.Windows.Forms.DataGridView();
            this.dgvLogs = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSessions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // cboNPC
            // 
            this.cboNPC.FormattingEnabled = true;
            this.cboNPC.Location = new System.Drawing.Point(12, 12);
            this.cboNPC.Name = "cboNPC";
            this.cboNPC.Size = new System.Drawing.Size(277, 21);
            this.cboNPC.TabIndex = 0;
            this.cboNPC.SelectedIndexChanged += new System.EventHandler(this.cboNPC_SelectedIndexChanged_1);
            // 
            // dgvSessions
            // 
            this.dgvSessions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSessions.Location = new System.Drawing.Point(12, 39);
            this.dgvSessions.Name = "dgvSessions";
            this.dgvSessions.Size = new System.Drawing.Size(347, 288);
            this.dgvSessions.TabIndex = 1;
            // 
            // dgvLogs
            // 
            this.dgvLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLogs.Location = new System.Drawing.Point(365, 39);
            this.dgvLogs.Name = "dgvLogs";
            this.dgvLogs.Size = new System.Drawing.Size(347, 288);
            this.dgvLogs.TabIndex = 1;
            this.dgvLogs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLogs_CellContentClick);
            // 
            // ReportStatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1284, 661);
            this.Controls.Add(this.dgvLogs);
            this.Controls.Add(this.dgvSessions);
            this.Controls.Add(this.cboNPC);
            this.Name = "ReportStatusForm";
            this.Text = "ReportStatusForm";
            this.Load += new System.EventHandler(this.ReportStatusForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSessions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboNPC;
        private System.Windows.Forms.DataGridView dgvSessions;
        private System.Windows.Forms.DataGridView dgvLogs;
    }
}