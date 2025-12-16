namespace NPCDialogueManager.App
{
    partial class NPCDialogueForm
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
            this.lstNodes = new System.Windows.Forms.ListBox();
            this.txtNodeId = new System.Windows.Forms.TextBox();
            this.txtNodeKey = new System.Windows.Forms.TextBox();
            this.txtNodeText = new System.Windows.Forms.TextBox();
            this.txtToNodeId = new System.Windows.Forms.TextBox();
            this.txtChoiceText = new System.Windows.Forms.TextBox();
            this.txtConditionExpr = new System.Windows.Forms.TextBox();
            this.chkIsRoot = new System.Windows.Forms.CheckBox();
            this.dgvEdges = new System.Windows.Forms.DataGridView();
            this.btnAddNode = new System.Windows.Forms.Button();
            this.btnUpdateNode = new System.Windows.Forms.Button();
            this.btnDeleteNode = new System.Windows.Forms.Button();
            this.btnAddEdge = new System.Windows.Forms.Button();
            this.btnDeleteEdge = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEdges)).BeginInit();
            this.SuspendLayout();
            // 
            // cboNPC
            // 
            this.cboNPC.FormattingEnabled = true;
            this.cboNPC.Location = new System.Drawing.Point(12, 12);
            this.cboNPC.Name = "cboNPC";
            this.cboNPC.Size = new System.Drawing.Size(211, 21);
            this.cboNPC.TabIndex = 0;
            this.cboNPC.SelectedIndexChanged += new System.EventHandler(this.cboNPC_SelectedIndexChanged_1);
            // 
            // lstNodes
            // 
            this.lstNodes.FormattingEnabled = true;
            this.lstNodes.Location = new System.Drawing.Point(12, 39);
            this.lstNodes.Name = "lstNodes";
            this.lstNodes.Size = new System.Drawing.Size(290, 160);
            this.lstNodes.TabIndex = 1;
            this.lstNodes.SelectedIndexChanged += new System.EventHandler(this.lstNodes_SelectedIndexChanged);
            // 
            // txtNodeId
            // 
            this.txtNodeId.Location = new System.Drawing.Point(306, 39);
            this.txtNodeId.Name = "txtNodeId";
            this.txtNodeId.ReadOnly = true;
            this.txtNodeId.Size = new System.Drawing.Size(100, 20);
            this.txtNodeId.TabIndex = 2;
            this.txtNodeId.TextChanged += new System.EventHandler(this.txtNodeId_TextChanged);
            // 
            // txtNodeKey
            // 
            this.txtNodeKey.Location = new System.Drawing.Point(306, 65);
            this.txtNodeKey.Name = "txtNodeKey";
            this.txtNodeKey.Size = new System.Drawing.Size(100, 20);
            this.txtNodeKey.TabIndex = 2;
            this.txtNodeKey.TextChanged += new System.EventHandler(this.txtNodeKey_TextChanged);
            // 
            // txtNodeText
            // 
            this.txtNodeText.Location = new System.Drawing.Point(306, 91);
            this.txtNodeText.Name = "txtNodeText";
            this.txtNodeText.Size = new System.Drawing.Size(100, 20);
            this.txtNodeText.TabIndex = 2;
            // 
            // txtToNodeId
            // 
            this.txtToNodeId.Location = new System.Drawing.Point(306, 117);
            this.txtToNodeId.Name = "txtToNodeId";
            this.txtToNodeId.Size = new System.Drawing.Size(100, 20);
            this.txtToNodeId.TabIndex = 2;
            // 
            // txtChoiceText
            // 
            this.txtChoiceText.Location = new System.Drawing.Point(306, 143);
            this.txtChoiceText.Name = "txtChoiceText";
            this.txtChoiceText.Size = new System.Drawing.Size(100, 20);
            this.txtChoiceText.TabIndex = 2;
            // 
            // txtConditionExpr
            // 
            this.txtConditionExpr.Location = new System.Drawing.Point(306, 169);
            this.txtConditionExpr.Name = "txtConditionExpr";
            this.txtConditionExpr.Size = new System.Drawing.Size(100, 20);
            this.txtConditionExpr.TabIndex = 2;
            // 
            // chkIsRoot
            // 
            this.chkIsRoot.AutoSize = true;
            this.chkIsRoot.Location = new System.Drawing.Point(324, 209);
            this.chkIsRoot.Name = "chkIsRoot";
            this.chkIsRoot.Size = new System.Drawing.Size(49, 17);
            this.chkIsRoot.TabIndex = 3;
            this.chkIsRoot.Text = "Root";
            this.chkIsRoot.UseVisualStyleBackColor = true;
            // 
            // dgvEdges
            // 
            this.dgvEdges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEdges.Location = new System.Drawing.Point(12, 259);
            this.dgvEdges.Name = "dgvEdges";
            this.dgvEdges.Size = new System.Drawing.Size(290, 179);
            this.dgvEdges.TabIndex = 4;
            // 
            // btnAddNode
            // 
            this.btnAddNode.Location = new System.Drawing.Point(12, 205);
            this.btnAddNode.Name = "btnAddNode";
            this.btnAddNode.Size = new System.Drawing.Size(98, 23);
            this.btnAddNode.TabIndex = 5;
            this.btnAddNode.Text = "Add Node";
            this.btnAddNode.UseVisualStyleBackColor = true;
            this.btnAddNode.Click += new System.EventHandler(this.btnAddNode_Click_1);
            // 
            // btnUpdateNode
            // 
            this.btnUpdateNode.Location = new System.Drawing.Point(116, 205);
            this.btnUpdateNode.Name = "btnUpdateNode";
            this.btnUpdateNode.Size = new System.Drawing.Size(98, 23);
            this.btnUpdateNode.TabIndex = 5;
            this.btnUpdateNode.Text = "Update Node";
            this.btnUpdateNode.UseVisualStyleBackColor = true;
            this.btnUpdateNode.Click += new System.EventHandler(this.btnUpdateNode_Click_1);
            // 
            // btnDeleteNode
            // 
            this.btnDeleteNode.Location = new System.Drawing.Point(220, 205);
            this.btnDeleteNode.Name = "btnDeleteNode";
            this.btnDeleteNode.Size = new System.Drawing.Size(98, 23);
            this.btnDeleteNode.TabIndex = 5;
            this.btnDeleteNode.Text = "Delete Node";
            this.btnDeleteNode.UseVisualStyleBackColor = true;
            this.btnDeleteNode.Click += new System.EventHandler(this.btnDeleteNode_Click_1);
            // 
            // btnAddEdge
            // 
            this.btnAddEdge.Location = new System.Drawing.Point(308, 259);
            this.btnAddEdge.Name = "btnAddEdge";
            this.btnAddEdge.Size = new System.Drawing.Size(98, 23);
            this.btnAddEdge.TabIndex = 5;
            this.btnAddEdge.Text = "Add Edge";
            this.btnAddEdge.UseVisualStyleBackColor = true;
            this.btnAddEdge.Click += new System.EventHandler(this.btnAddEdge_Click_1);
            // 
            // btnDeleteEdge
            // 
            this.btnDeleteEdge.Location = new System.Drawing.Point(308, 288);
            this.btnDeleteEdge.Name = "btnDeleteEdge";
            this.btnDeleteEdge.Size = new System.Drawing.Size(98, 23);
            this.btnDeleteEdge.TabIndex = 5;
            this.btnDeleteEdge.Text = "Delete Edge";
            this.btnDeleteEdge.UseVisualStyleBackColor = true;
            this.btnDeleteEdge.Click += new System.EventHandler(this.btnDeleteEdge_Click_1);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(229, 20);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(29, 13);
            this.label.TabIndex = 6;
            this.label.Text = "NPC";
            // 
            // NPCDialogueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1284, 661);
            this.Controls.Add(this.label);
            this.Controls.Add(this.btnDeleteEdge);
            this.Controls.Add(this.btnAddEdge);
            this.Controls.Add(this.btnDeleteNode);
            this.Controls.Add(this.btnUpdateNode);
            this.Controls.Add(this.btnAddNode);
            this.Controls.Add(this.dgvEdges);
            this.Controls.Add(this.chkIsRoot);
            this.Controls.Add(this.txtConditionExpr);
            this.Controls.Add(this.txtChoiceText);
            this.Controls.Add(this.txtToNodeId);
            this.Controls.Add(this.txtNodeText);
            this.Controls.Add(this.txtNodeKey);
            this.Controls.Add(this.txtNodeId);
            this.Controls.Add(this.lstNodes);
            this.Controls.Add(this.cboNPC);
            this.Name = "NPCDialogueForm";
            this.Text = "NPCDialogueForm";
            this.Load += new System.EventHandler(this.NPCDialogueForm_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEdges)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboNPC;
        private System.Windows.Forms.ListBox lstNodes;
        private System.Windows.Forms.TextBox txtNodeId;
        private System.Windows.Forms.TextBox txtNodeKey;
        private System.Windows.Forms.TextBox txtNodeText;
        private System.Windows.Forms.TextBox txtToNodeId;
        private System.Windows.Forms.TextBox txtChoiceText;
        private System.Windows.Forms.TextBox txtConditionExpr;
        private System.Windows.Forms.CheckBox chkIsRoot;
        private System.Windows.Forms.DataGridView dgvEdges;
        private System.Windows.Forms.Button btnAddNode;
        private System.Windows.Forms.Button btnUpdateNode;
        private System.Windows.Forms.Button btnDeleteNode;
        private System.Windows.Forms.Button btnAddEdge;
        private System.Windows.Forms.Button btnDeleteEdge;
        private System.Windows.Forms.Label label;
    }
}