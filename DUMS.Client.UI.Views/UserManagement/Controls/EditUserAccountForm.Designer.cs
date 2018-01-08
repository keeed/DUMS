namespace DUMS.Client.UI.Views.UserManagement.Controls
{
    partial class EditUserAccountForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panelUserInfo = new System.Windows.Forms.Panel();
            this.datetimepickerBirthdate = new System.Windows.Forms.DateTimePicker();
            this.labelBirthdate = new System.Windows.Forms.Label();
            this.textboxLastName = new System.Windows.Forms.TextBox();
            this.labelFirstName = new System.Windows.Forms.Label();
            this.labelLastName = new System.Windows.Forms.Label();
            this.textboxFirstName = new System.Windows.Forms.TextBox();
            this.groupboxUserAccount = new System.Windows.Forms.GroupBox();
            this.panelUserAccount = new System.Windows.Forms.Panel();
            this.comboboxUserType = new System.Windows.Forms.ComboBox();
            this.labelUserType = new System.Windows.Forms.Label();
            this.textboxPassword = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelUserID = new System.Windows.Forms.Label();
            this.textboxUsername = new System.Windows.Forms.TextBox();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelUserIDText = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panelUserInfo.SuspendLayout();
            this.groupboxUserAccount.SuspendLayout();
            this.panelUserAccount.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Controls.Add(this.buttonEdit);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupboxUserAccount);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(357, 330);
            this.panel1.TabIndex = 0;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(264, 291);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(183, 291);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonEdit.TabIndex = 2;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.panelUserInfo);
            this.groupBox2.Location = new System.Drawing.Point(12, 165);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(330, 120);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "User Info";
            // 
            // panelUserInfo
            // 
            this.panelUserInfo.Controls.Add(this.datetimepickerBirthdate);
            this.panelUserInfo.Controls.Add(this.labelBirthdate);
            this.panelUserInfo.Controls.Add(this.textboxLastName);
            this.panelUserInfo.Controls.Add(this.labelFirstName);
            this.panelUserInfo.Controls.Add(this.labelLastName);
            this.panelUserInfo.Controls.Add(this.textboxFirstName);
            this.panelUserInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUserInfo.Location = new System.Drawing.Point(3, 16);
            this.panelUserInfo.Name = "panelUserInfo";
            this.panelUserInfo.Size = new System.Drawing.Size(324, 101);
            this.panelUserInfo.TabIndex = 0;
            // 
            // datetimepickerBirthdate
            // 
            this.datetimepickerBirthdate.Location = new System.Drawing.Point(102, 63);
            this.datetimepickerBirthdate.Name = "datetimepickerBirthdate";
            this.datetimepickerBirthdate.Size = new System.Drawing.Size(200, 20);
            this.datetimepickerBirthdate.TabIndex = 16;
            // 
            // labelBirthdate
            // 
            this.labelBirthdate.AutoSize = true;
            this.labelBirthdate.Location = new System.Drawing.Point(22, 69);
            this.labelBirthdate.Name = "labelBirthdate";
            this.labelBirthdate.Size = new System.Drawing.Size(52, 13);
            this.labelBirthdate.TabIndex = 15;
            this.labelBirthdate.Text = "Birthdate:";
            // 
            // textboxLastName
            // 
            this.textboxLastName.Location = new System.Drawing.Point(102, 37);
            this.textboxLastName.Name = "textboxLastName";
            this.textboxLastName.Size = new System.Drawing.Size(200, 20);
            this.textboxLastName.TabIndex = 14;
            // 
            // labelFirstName
            // 
            this.labelFirstName.AutoSize = true;
            this.labelFirstName.Location = new System.Drawing.Point(23, 14);
            this.labelFirstName.Name = "labelFirstName";
            this.labelFirstName.Size = new System.Drawing.Size(60, 13);
            this.labelFirstName.TabIndex = 11;
            this.labelFirstName.Text = "First Name:";
            // 
            // labelLastName
            // 
            this.labelLastName.AutoSize = true;
            this.labelLastName.Location = new System.Drawing.Point(22, 40);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Size = new System.Drawing.Size(61, 13);
            this.labelLastName.TabIndex = 13;
            this.labelLastName.Text = "Last Name:";
            // 
            // textboxFirstName
            // 
            this.textboxFirstName.Location = new System.Drawing.Point(102, 11);
            this.textboxFirstName.Name = "textboxFirstName";
            this.textboxFirstName.Size = new System.Drawing.Size(200, 20);
            this.textboxFirstName.TabIndex = 12;
            // 
            // groupboxUserAccount
            // 
            this.groupboxUserAccount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupboxUserAccount.Controls.Add(this.panelUserAccount);
            this.groupboxUserAccount.Location = new System.Drawing.Point(12, 12);
            this.groupboxUserAccount.Name = "groupboxUserAccount";
            this.groupboxUserAccount.Size = new System.Drawing.Size(333, 147);
            this.groupboxUserAccount.TabIndex = 0;
            this.groupboxUserAccount.TabStop = false;
            this.groupboxUserAccount.Text = "User Account";
            // 
            // panelUserAccount
            // 
            this.panelUserAccount.Controls.Add(this.comboboxUserType);
            this.panelUserAccount.Controls.Add(this.labelUserType);
            this.panelUserAccount.Controls.Add(this.textboxPassword);
            this.panelUserAccount.Controls.Add(this.labelPassword);
            this.panelUserAccount.Controls.Add(this.labelUserID);
            this.panelUserAccount.Controls.Add(this.textboxUsername);
            this.panelUserAccount.Controls.Add(this.labelUsername);
            this.panelUserAccount.Controls.Add(this.labelUserIDText);
            this.panelUserAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUserAccount.Location = new System.Drawing.Point(3, 16);
            this.panelUserAccount.Name = "panelUserAccount";
            this.panelUserAccount.Size = new System.Drawing.Size(327, 128);
            this.panelUserAccount.TabIndex = 0;
            // 
            // comboboxUserType
            // 
            this.comboboxUserType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboboxUserType.FormattingEnabled = true;
            this.comboboxUserType.Location = new System.Drawing.Point(102, 88);
            this.comboboxUserType.Name = "comboboxUserType";
            this.comboboxUserType.Size = new System.Drawing.Size(200, 21);
            this.comboboxUserType.TabIndex = 10;
            // 
            // labelUserType
            // 
            this.labelUserType.AutoSize = true;
            this.labelUserType.Location = new System.Drawing.Point(22, 91);
            this.labelUserType.Name = "labelUserType";
            this.labelUserType.Size = new System.Drawing.Size(59, 13);
            this.labelUserType.TabIndex = 9;
            this.labelUserType.Text = "User Type:";
            // 
            // textboxPassword
            // 
            this.textboxPassword.Location = new System.Drawing.Point(102, 62);
            this.textboxPassword.Name = "textboxPassword";
            this.textboxPassword.PasswordChar = '*';
            this.textboxPassword.Size = new System.Drawing.Size(200, 20);
            this.textboxPassword.TabIndex = 8;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(22, 65);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(56, 13);
            this.labelPassword.TabIndex = 7;
            this.labelPassword.Text = "Password:";
            // 
            // labelUserID
            // 
            this.labelUserID.AutoSize = true;
            this.labelUserID.Location = new System.Drawing.Point(99, 13);
            this.labelUserID.Name = "labelUserID";
            this.labelUserID.Size = new System.Drawing.Size(30, 13);
            this.labelUserID.TabIndex = 6;
            this.labelUserID.Text = "<ID>";
            // 
            // textboxUsername
            // 
            this.textboxUsername.Location = new System.Drawing.Point(102, 36);
            this.textboxUsername.Name = "textboxUsername";
            this.textboxUsername.Size = new System.Drawing.Size(200, 20);
            this.textboxUsername.TabIndex = 5;
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(22, 39);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(58, 13);
            this.labelUsername.TabIndex = 4;
            this.labelUsername.Text = "Username:";
            // 
            // labelUserIDText
            // 
            this.labelUserIDText.AutoSize = true;
            this.labelUserIDText.Location = new System.Drawing.Point(22, 13);
            this.labelUserIDText.Name = "labelUserIDText";
            this.labelUserIDText.Size = new System.Drawing.Size(46, 13);
            this.labelUserIDText.TabIndex = 1;
            this.labelUserIDText.Text = "User ID:";
            // 
            // EditUserAccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 330);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditUserAccountForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit User";
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panelUserInfo.ResumeLayout(false);
            this.panelUserInfo.PerformLayout();
            this.groupboxUserAccount.ResumeLayout(false);
            this.panelUserAccount.ResumeLayout(false);
            this.panelUserAccount.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupboxUserAccount;
        private System.Windows.Forms.Panel panelUserAccount;
        private System.Windows.Forms.Label labelUserIDText;
        private System.Windows.Forms.TextBox textboxUsername;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelUserID;
        private System.Windows.Forms.TextBox textboxPassword;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelUserType;
        private System.Windows.Forms.ComboBox comboboxUserType;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panelUserInfo;
        private System.Windows.Forms.TextBox textboxLastName;
        private System.Windows.Forms.Label labelFirstName;
        private System.Windows.Forms.Label labelLastName;
        private System.Windows.Forms.TextBox textboxFirstName;
        private System.Windows.Forms.Label labelBirthdate;
        private System.Windows.Forms.DateTimePicker datetimepickerBirthdate;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonEdit;
    }
}