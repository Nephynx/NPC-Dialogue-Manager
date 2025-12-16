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
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cboNPC
            // 
            this.cboNPC.FormattingEnabled = true;
            this.cboNPC.Location = new System.Drawing.Point(12, 242);
            this.cboNPC.Name = "cboNPC";
            this.cboNPC.Size = new System.Drawing.Size(226, 21);
            this.cboNPC.TabIndex = 0;
            // 
            // lblNpcName
            // 
            this.lblNpcName.AutoSize = true;
            this.lblNpcName.Location = new System.Drawing.Point(198, 245);
            this.lblNpcName.Name = "lblNpcName";
            this.lblNpcName.Size = new System.Drawing.Size(0, 13);
            this.lblNpcName.TabIndex = 1;
            // 
            // lblNodeId
            // 
            this.lblNodeId.AutoSize = true;
            this.lblNodeId.Location = new System.Drawing.Point(198, 272);
            this.lblNodeId.Name = "lblNodeId";
            this.lblNodeId.Size = new System.Drawing.Size(0, 13);
            this.lblNodeId.TabIndex = 1;
            // 
            // txtNodeText
            // 
            this.txtNodeText.Location = new System.Drawing.Point(12, 269);
            this.txtNodeText.Name = "txtNodeText";
            this.txtNodeText.Size = new System.Drawing.Size(180, 20);
            this.txtNodeText.TabIndex = 2;
            // 
            // lstChoices
            // 
            this.lstChoices.FormattingEnabled = true;
            this.lstChoices.Location = new System.Drawing.Point(12, 324);
            this.lstChoices.Name = "lstChoices";
            this.lstChoices.Size = new System.Drawing.Size(560, 225);
            this.lstChoices.TabIndex = 3;
            this.lstChoices.SelectedIndexChanged += new System.EventHandler(this.lstChoices_SelectedIndexChanged);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 295);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(138, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.Location = new System.Drawing.Point(156, 295);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(138, 23);
            this.btnEnd.TabIndex = 4;
            this.btnEnd.Text = "End";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(244, 245);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "NPC";
            // 
            // DialoguePlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lstChoices);
            this.Controls.Add(this.txtNodeText);
            this.Controls.Add(this.lblNodeId);
            this.Controls.Add(this.lblNpcName);
            this.Controls.Add(this.cboNPC);
            this.Name = "DialoguePlayerForm";
            this.Text = "DialoguePlayer";
            this.Load += new System.EventHandler(this.DialoguePlayerForm_Load_1);
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
        private System.Windows.Forms.Label label1;
    }
}