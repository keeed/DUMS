namespace DUMS.Client.UI.Views.UserManagement
{
    partial class HomeForm
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolstripmenuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolstripmenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMain = new System.Windows.Forms.Panel();
            this.userAccountSearchControl = new DUMS.Client.UI.Views.UserManagement.Controls.UserAccountSearchControl();
            this.userControls = new DUMS.Client.UI.Views.UserManagement.Controls.UserControls();
            this.userAccountTable = new DUMS.Client.UI.Views.UserManagement.Controls.UserAccountTable();
            this.menuStrip.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(832, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolstripmenuLogout,
            this.toolstripmenuExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // toolstripmenuLogout
            // 
            this.toolstripmenuLogout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolstripmenuLogout.Name = "toolstripmenuLogout";
            this.toolstripmenuLogout.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.toolstripmenuLogout.Size = new System.Drawing.Size(152, 22);
            this.toolstripmenuLogout.Text = "&Logout";
            this.toolstripmenuLogout.Click += new System.EventHandler(this.toolstripmenuLogout_Click);
            // 
            // toolstripmenuExit
            // 
            this.toolstripmenuExit.Name = "toolstripmenuExit";
            this.toolstripmenuExit.Size = new System.Drawing.Size(152, 22);
            this.toolstripmenuExit.Text = "E&xit";
            this.toolstripmenuExit.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.userAccountSearchControl);
            this.panelMain.Controls.Add(this.userControls);
            this.panelMain.Controls.Add(this.userAccountTable);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 24);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(832, 393);
            this.panelMain.TabIndex = 1;
            // 
            // userAccountSearchControl
            // 
            this.userAccountSearchControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userAccountSearchControl.Location = new System.Drawing.Point(3, 3);
            this.userAccountSearchControl.Name = "userAccountSearchControl";
            this.userAccountSearchControl.Size = new System.Drawing.Size(826, 58);
            this.userAccountSearchControl.TabIndex = 2;
            this.userAccountSearchControl.UserAccountPresenter = null;
            // 
            // userControls
            // 
            this.userControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userControls.Location = new System.Drawing.Point(3, 318);
            this.userControls.Name = "userControls";
            this.userControls.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.userControls.Size = new System.Drawing.Size(826, 72);
            this.userControls.TabIndex = 1;
            this.userControls.UserAccountPresenter = null;
            this.userControls.userAccountTable = null;
            // 
            // userAccountTable
            // 
            this.userAccountTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userAccountTable.Location = new System.Drawing.Point(3, 67);
            this.userAccountTable.Name = "userAccountTable";
            this.userAccountTable.Size = new System.Drawing.Size(826, 240);
            this.userAccountTable.TabIndex = 0;
            this.userAccountTable.UserAccountPresenter = null;
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 417);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "HomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DUMS - Home";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolstripmenuLogout;
        private System.Windows.Forms.ToolStripMenuItem toolstripmenuExit;
        private System.Windows.Forms.Panel panelMain;
        private Controls.UserAccountTable userAccountTable;
        private Controls.UserControls userControls;
        private Controls.UserAccountSearchControl userAccountSearchControl;

    }
}