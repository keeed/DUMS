namespace DUMS.Client.UI.Views.UserManagement.Controls
{
    partial class UserAccountSearchControl
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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.groupboxSearch = new System.Windows.Forms.GroupBox();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.labelInstruction2 = new System.Windows.Forms.Label();
            this.comboboxSearchCriteria = new System.Windows.Forms.ComboBox();
            this.textboxSearch = new System.Windows.Forms.TextBox();
            this.labelInstruction1 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.groupboxSearch.SuspendLayout();
            this.panelSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.groupboxSearch);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(598, 58);
            this.mainPanel.TabIndex = 0;
            // 
            // groupboxSearch
            // 
            this.groupboxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupboxSearch.Controls.Add(this.panelSearch);
            this.groupboxSearch.Location = new System.Drawing.Point(3, 3);
            this.groupboxSearch.Name = "groupboxSearch";
            this.groupboxSearch.Size = new System.Drawing.Size(592, 49);
            this.groupboxSearch.TabIndex = 0;
            this.groupboxSearch.TabStop = false;
            this.groupboxSearch.Text = "Search";
            // 
            // panelSearch
            // 
            this.panelSearch.AutoScroll = true;
            this.panelSearch.Controls.Add(this.btnClear);
            this.panelSearch.Controls.Add(this.buttonSearch);
            this.panelSearch.Controls.Add(this.labelInstruction2);
            this.panelSearch.Controls.Add(this.comboboxSearchCriteria);
            this.panelSearch.Controls.Add(this.textboxSearch);
            this.panelSearch.Controls.Add(this.labelInstruction1);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSearch.Location = new System.Drawing.Point(3, 16);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(586, 30);
            this.panelSearch.TabIndex = 0;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(420, 1);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 4;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // labelInstruction2
            // 
            this.labelInstruction2.AutoSize = true;
            this.labelInstruction2.Location = new System.Drawing.Point(207, 6);
            this.labelInstruction2.Name = "labelInstruction2";
            this.labelInstruction2.Size = new System.Drawing.Size(71, 13);
            this.labelInstruction2.TabIndex = 3;
            this.labelInstruction2.Text = "that contains ";
            // 
            // comboboxSearchCriteria
            // 
            this.comboboxSearchCriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboboxSearchCriteria.FormattingEnabled = true;
            this.comboboxSearchCriteria.Location = new System.Drawing.Point(80, 3);
            this.comboboxSearchCriteria.Name = "comboboxSearchCriteria";
            this.comboboxSearchCriteria.Size = new System.Drawing.Size(121, 21);
            this.comboboxSearchCriteria.TabIndex = 2;
            // 
            // textboxSearch
            // 
            this.textboxSearch.Location = new System.Drawing.Point(284, 3);
            this.textboxSearch.Name = "textboxSearch";
            this.textboxSearch.Size = new System.Drawing.Size(130, 20);
            this.textboxSearch.TabIndex = 1;
            // 
            // labelInstruction1
            // 
            this.labelInstruction1.AutoSize = true;
            this.labelInstruction1.Location = new System.Drawing.Point(20, 6);
            this.labelInstruction1.Name = "labelInstruction1";
            this.labelInstruction1.Size = new System.Drawing.Size(54, 13);
            this.labelInstruction1.TabIndex = 0;
            this.labelInstruction1.Text = "Search all";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(501, 1);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // UserAccountSearchControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.Name = "UserAccountSearchControl";
            this.Size = new System.Drawing.Size(598, 58);
            this.mainPanel.ResumeLayout(false);
            this.groupboxSearch.ResumeLayout(false);
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.GroupBox groupboxSearch;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Label labelInstruction1;
        private System.Windows.Forms.TextBox textboxSearch;
        private System.Windows.Forms.ComboBox comboboxSearchCriteria;
        private System.Windows.Forms.Label labelInstruction2;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button btnClear;
    }
}
