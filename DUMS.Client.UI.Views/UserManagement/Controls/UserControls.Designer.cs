namespace DUMS.Client.UI.Views.UserManagement.Controls
{
    partial class UserControls
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowlayoutpanelButtonControls = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonUnlock = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.groupboxUserButtonControls = new System.Windows.Forms.GroupBox();
            this.flowlayoutpanelButtonControls.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.groupboxUserButtonControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowlayoutpanelButtonControls
            // 
            this.flowlayoutpanelButtonControls.AutoScroll = true;
            this.flowlayoutpanelButtonControls.Controls.Add(this.buttonAdd);
            this.flowlayoutpanelButtonControls.Controls.Add(this.buttonEdit);
            this.flowlayoutpanelButtonControls.Controls.Add(this.buttonUnlock);
            this.flowlayoutpanelButtonControls.Controls.Add(this.buttonDelete);
            this.flowlayoutpanelButtonControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowlayoutpanelButtonControls.Location = new System.Drawing.Point(3, 16);
            this.flowlayoutpanelButtonControls.Name = "flowlayoutpanelButtonControls";
            this.flowlayoutpanelButtonControls.Size = new System.Drawing.Size(358, 38);
            this.flowlayoutpanelButtonControls.TabIndex = 0;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(3, 3);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "&Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(84, 3);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonEdit.TabIndex = 1;
            this.buttonEdit.Text = "&Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonUnlock
            // 
            this.buttonUnlock.Location = new System.Drawing.Point(165, 3);
            this.buttonUnlock.Name = "buttonUnlock";
            this.buttonUnlock.Size = new System.Drawing.Size(75, 23);
            this.buttonUnlock.TabIndex = 3;
            this.buttonUnlock.Text = "&Unlock";
            this.buttonUnlock.UseVisualStyleBackColor = true;
            this.buttonUnlock.Click += new System.EventHandler(this.buttonUnlock_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(246, 3);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 0;
            this.buttonDelete.Text = "&Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.AutoScroll = true;
            this.mainPanel.Controls.Add(this.groupboxUserButtonControls);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(370, 66);
            this.mainPanel.TabIndex = 1;
            // 
            // groupboxUserButtonControls
            // 
            this.groupboxUserButtonControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupboxUserButtonControls.Controls.Add(this.flowlayoutpanelButtonControls);
            this.groupboxUserButtonControls.Location = new System.Drawing.Point(3, 3);
            this.groupboxUserButtonControls.Name = "groupboxUserButtonControls";
            this.groupboxUserButtonControls.Size = new System.Drawing.Size(364, 57);
            this.groupboxUserButtonControls.TabIndex = 1;
            this.groupboxUserButtonControls.TabStop = false;
            this.groupboxUserButtonControls.Text = "Controls";
            // 
            // UserControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.Name = "UserControls";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Size = new System.Drawing.Size(370, 66);
            this.flowlayoutpanelButtonControls.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.groupboxUserButtonControls.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowlayoutpanelButtonControls;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonUnlock;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.GroupBox groupboxUserButtonControls;


    }
}
