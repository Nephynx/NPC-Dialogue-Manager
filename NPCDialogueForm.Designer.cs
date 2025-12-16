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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
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
            // 
            // txtNodeKey
            // 
            this.txtNodeKey.Location = new System.Drawing.Point(306, 65);
            this.txtNodeKey.Name = "txtNodeKey";
            this.txtNodeKey.Size = new System.Drawing.Size(100, 20);
            this.txtNodeKey.TabIndex = 2;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(412, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "NodeId";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(412, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Condition";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(412, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "NodeKey";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(412, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "NodeText";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(412, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Choice";
            // 
            // NPCDialogueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1284, 661);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
    }
}