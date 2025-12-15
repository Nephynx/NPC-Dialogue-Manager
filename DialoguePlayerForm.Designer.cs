namespace NPCDialogueManager.App
{
    partial class DialoguePlayerForm
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
            this.lblNpcName = new System.Windows.Forms.Label();
            this.lblNodeId = new System.Windows.Forms.Label();
            this.txtNodeText = new System.Windows.Forms.TextBox();
            this.lstChoices = new System.Windows.Forms.ListBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnEnd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboNPC
            // 
            this.cboNPC.FormattingEnabled = true;
            this.cboNPC.Location = new System.Drawing.Point(12, 12);
            this.cboNPC.Name = "cboNPC";
            this.cboNPC.Size = new System.Drawing.Size(180, 21);
            this.cboNPC.TabIndex = 0;
            // 
            // lblNpcName
            // 
            this.lblNpcName.AutoSize = true;
            this.lblNpcName.Location = new System.Drawing.Point(198, 15);
            this.lblNpcName.Name = "lblNpcName";
            this.lblNpcName.Size = new System.Drawing.Size(0, 13);
            this.lblNpcName.TabIndex = 1;
            // 
            // lblNodeId
            // 
            this.lblNodeId.AutoSize = true;
            this.lblNodeId.Location = new System.Drawing.Point(198, 42);
            this.lblNodeId.Name = "lblNodeId";
            this.lblNodeId.Size = new System.Drawing.Size(0, 13);
            this.lblNodeId.TabIndex = 1;
            // 
            // txtNodeText
            // 
            this.txtNodeText.Location = new System.Drawing.Point(12, 39);
            this.txtNodeText.Name = "txtNodeText";
            this.txtNodeText.Size = new System.Drawing.Size(180, 20);
            this.txtNodeText.TabIndex = 2;
            // 
            // lstChoices
            // 
            this.lstChoices.FormattingEnabled = true;
            this.lstChoices.Location = new System.Drawing.Point(12, 65);
            this.lstChoices.Name = "lstChoices";
            this.lstChoices.Size = new System.Drawing.Size(366, 225);
            this.lstChoices.TabIndex = 3;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 296);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(138, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.Location = new System.Drawing.Point(240, 296);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(138, 23);
            this.btnEnd.TabIndex = 4;
            this.btnEnd.Text = "End";
            this.btnEnd.UseVisualStyleBackColor = true;
            // 
            // DialoguePlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 661);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lstChoices);
            this.Controls.Add(this.txtNodeText);
            this.Controls.Add(this.lblNodeId);
            this.Controls.Add(this.lblNpcName);
            this.Controls.Add(this.cboNPC);
            this.Name = "DialoguePlayerForm";
            this.Text = "DialoguePlayer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboNPC;
        private System.Windows.Forms.Label lblNpcName;
        private System.Windows.Forms.Label lblNodeId;
        private System.Windows.Forms.TextBox txtNodeText;
        private System.Windows.Forms.ListBox lstChoices;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnEnd;
    }
}