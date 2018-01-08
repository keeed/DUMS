namespace DUMS.Client.UI.Views.UserManagement.Controls
{
    partial class AddUserAccountForm
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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupboxUserInfo = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.datetimepickerBirthdate = new System.Windows.Forms.DateTimePicker();
            this.labelFirstName = new System.Windows.Forms.Label();
            this.labelBirthdate = new System.Windows.Forms.Label();
            this.textboxFirstName = new System.Windows.Forms.TextBox();
            this.textboxLastname = new System.Windows.Forms.TextBox();
            this.labelLastName = new System.Windows.Forms.Label();
            this.groupboxUserAccount = new System.Windows.Forms.GroupBox();
            this.panelUserAccount = new System.Windows.Forms.Panel();
            this.comboboxUserType = new System.Windows.Forms.ComboBox();
            this.labelUserType = new System.Windows.Forms.Label();
            this.textboxRetypePassword = new System.Windows.Forms.TextBox();
            this.labelRetypePassword = new System.Windows.Forms.Label();
            this.textboxPassword = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textboxUsername = new System.Windows.Forms.TextBox();
            this.labelUsername = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.groupboxUserInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupboxUserAccount.SuspendLayout();
            this.panelUserAccount.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.AutoScroll = true;
            this.mainPanel.Controls.Add(this.buttonAdd);
            this.mainPanel.Controls.Add(this.buttonCancel);
            this.mainPanel.Controls.Add(this.groupboxUserInfo);
            this.mainPanel.Controls.Add(this.groupboxUserAccount);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(385, 343);
            this.mainPanel.TabIndex = 0;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(210, 306);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 3;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(292, 306);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupboxUserInfo
            // 
            this.groupboxUserInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupboxUserInfo.Controls.Add(this.panel1);
            this.groupboxUserInfo.Location = new System.Drawing.Point(12, 173);
            this.groupboxUserInfo.Name = "groupboxUserInfo";
            this.groupboxUserInfo.Size = new System.Drawing.Size(358, 127);
            this.groupboxUserInfo.TabIndex = 1;
            this.groupboxUserInfo.TabStop = false;
            this.groupboxUserInfo.Text = "UserInfo";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.datetimepickerBirthdate);
            this.panel1.Controls.Add(this.labelFirstName);
            this.panel1.Controls.Add(this.labelBirthdate);
            this.panel1.Controls.Add(this.textboxFirstName);
            this.panel1.Controls.Add(this.textboxLastname);
            this.panel1.Controls.Add(this.labelLastName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(352, 108);
            this.panel1.TabIndex = 4;
            // 
            // datetimepickerBirthdate
            // 
            this.datetimepickerBirthdate.Location = new System.Drawing.Point(129, 63);
            this.datetimepickerBirthdate.Name = "datetimepickerBirthdate";
            this.datetimepickerBirthdate.Size = new System.Drawing.Size(200, 20);
            this.datetimepickerBirthdate.TabIndex = 7;
            // 
            // labelFirstName
            // 
            this.labelFirstName.AutoSize = true;
            this.labelFirstName.Location = new System.Drawing.Point(21, 14);
            this.labelFirstName.Name = "labelFirstName";
            this.labelFirstName.Size = new System.Drawing.Size(60, 13);
            this.labelFirstName.TabIndex = 2;
            this.labelFirstName.Text = "First Name:";
            // 
            // labelBirthdate
            // 
            this.labelBirthdate.AutoSize = true;
            this.labelBirthdate.Location = new System.Drawing.Point(22, 69);
            this.labelBirthdate.Name = "labelBirthdate";
            this.labelBirthdate.Size = new System.Drawing.Size(52, 13);
            this.labelBirthdate.TabIndex = 6;
            this.labelBirthdate.Text = "Birthdate:";
            // 
            // textboxFirstName
            // 
            this.textboxFirstName.Location = new System.Drawing.Point(129, 11);
            this.textboxFirstName.Name = "textboxFirstName";
            this.textboxFirstName.Size = new System.Drawing.Size(200, 20);
            this.textboxFirstName.TabIndex = 3;
            // 
            // textboxLastname
            // 
            this.textboxLastname.Location = new System.Drawing.Point(129, 37);
            this.textboxLastname.Name = "textboxLastname";
            this.textboxLastname.Size = new System.Drawing.Size(200, 20);
            this.textboxLastname.TabIndex = 5;
            // 
            // labelLastName
            // 
            this.labelLastName.AutoSize = true;
            this.labelLastName.Location = new System.Drawing.Point(23, 40);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Size = new System.Drawing.Size(61, 13);
            this.labelLastName.TabIndex = 4;
            this.labelLastName.Text = "Last Name:";
            // 
            // groupboxUserAccount
            // 
            this.groupboxUserAccount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupboxUserAccount.Controls.Add(this.panelUserAccount);
            this.groupboxUserAccount.Location = new System.Drawing.Point(12, 12);
            this.groupboxUserAccount.Name = "groupboxUserAccount";
            this.groupboxUserAccount.Size = new System.Drawing.Size(361, 155);
            this.groupboxUserAccount.TabIndex = 0;
            this.groupboxUserAccount.TabStop = false;
            this.groupboxUserAccount.Text = "User Account";
            // 
            // panelUserAccount
            // 
            this.panelUserAccount.AutoScroll = true;
            this.panelUserAccount.Controls.Add(this.comboboxUserType);
            this.panelUserAccount.Controls.Add(this.labelUserType);
            this.panelUserAccount.Controls.Add(this.textboxRetypePassword);
            this.panelUserAccount.Controls.Add(this.labelRetypePassword);
            this.panelUserAccount.Controls.Add(this.textboxPassword);
            this.panelUserAccount.Controls.Add(this.labelPassword);
            this.panelUserAccount.Controls.Add(this.textboxUsername);
            this.panelUserAccount.Controls.Add(this.labelUsername);
            this.panelUserAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUserAccount.Location = new System.Drawing.Point(3, 16);
            this.panelUserAccount.Name = "panelUserAccount";
            this.panelUserAccount.Size = new System.Drawing.Size(355, 136);
            this.panelUserAccount.TabIndex = 0;
            // 
            // comboboxUserType
            // 
            this.comboboxUserType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboboxUserType.FormattingEnabled = true;
            this.comboboxUserType.Location = new System.Drawing.Point(127, 98);
            this.comboboxUserType.Name = "comboboxUserType";
            this.comboboxUserType.Size = new System.Drawing.Size(202, 21);
            this.comboboxUserType.TabIndex = 7;
            // 
            // labelUserType
            // 
            this.labelUserType.AutoSize = true;
            this.labelUserType.Location = new System.Drawing.Point(21, 98);
            this.labelUserType.Name = "labelUserType";
            this.labelUserType.Size = new System.Drawing.Size(59, 13);
            this.labelUserType.TabIndex = 6;
            this.labelUserType.Text = "User Type:";
            // 
            // textboxRetypePassword
            // 
            this.textboxRetypePassword.Location = new System.Drawing.Point(127, 69);
            this.textboxRetypePassword.Name = "textboxRetypePassword";
            this.textboxRetypePassword.PasswordChar = '*';
            this.textboxRetypePassword.Size = new System.Drawing.Size(202, 20);
            this.textboxRetypePassword.TabIndex = 5;
            // 
            // labelRetypePassword
            // 
            this.labelRetypePassword.AutoSize = true;
            this.labelRetypePassword.Location = new System.Drawing.Point(21, 72);
            this.labelRetypePassword.Name = "labelRetypePassword";
            this.labelRetypePassword.Size = new System.Drawing.Size(100, 13);
            this.labelRetypePassword.TabIndex = 4;
            this.labelRetypePassword.Text = "Re-Type Password:";
            // 
            // textboxPassword
            // 
            this.textboxPassword.Location = new System.Drawing.Point(127, 43);
            this.textboxPassword.Name = "textboxPassword";
            this.textboxPassword.PasswordChar = '*';
            this.textboxPassword.Size = new System.Drawing.Size(202, 20);
            this.textboxPassword.TabIndex = 3;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(21, 46);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(56, 13);
            this.labelPassword.TabIndex = 2;
            this.labelPassword.Text = "Password:";
            // 
            // textboxUsername
            // 
            this.textboxUsername.Location = new System.Drawing.Point(127, 17);
            this.textboxUsername.Name = "textboxUsername";
            this.textboxUsername.Size = new System.Drawing.Size(202, 20);
            this.textboxUsername.TabIndex = 1;
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(21, 20);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(58, 13);
            this.labelUsername.TabIndex = 0;
            this.labelUsername.Text = "Username:";
            // 
            // AddUserAccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 343);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddUserAccountForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add User";
            this.mainPanel.ResumeLayout(false);
            this.groupboxUserInfo.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupboxUserAccount.ResumeLayout(false);
            this.panelUserAccount.ResumeLayout(false);
            this.panelUserAccount.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.GroupBox groupboxUserAccount;
        private System.Windows.Forms.Panel panelUserAccount;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.TextBox textboxUsername;
        private System.Windows.Forms.TextBox textboxPassword;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textboxRetypePassword;
        private System.Windows.Forms.Label labelRetypePassword;
        private System.Windows.Forms.Label labelUserType;
        private System.Windows.Forms.ComboBox comboboxUserType;
        private System.Windows.Forms.GroupBox groupboxUserInfo;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TextBox textboxFirstName;
        private System.Windows.Forms.Label labelFirstName;
        private System.Windows.Forms.TextBox textboxLastname;
        private System.Windows.Forms.Label labelLastName;
        private System.Windows.Forms.Label labelBirthdate;
        private System.Windows.Forms.DateTimePicker datetimepickerBirthdate;
        private System.Windows.Forms.Panel panel1;


    }
}