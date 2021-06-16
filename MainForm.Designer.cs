namespace requester_rebase
{
    partial class MainForm
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
            this.grbLogin = new System.Windows.Forms.GroupBox();
            this.AccessTokenLabel = new System.Windows.Forms.Label();
            this.txtAccessToken = new System.Windows.Forms.TextBox();
            this.txtSessionToken = new System.Windows.Forms.TextBox();
            this.SessionTokenLabel = new System.Windows.Forms.Label();
            this.HardwareIDLabel = new System.Windows.Forms.Label();
            this.txtHWID = new System.Windows.Forms.TextBox();
            this.SessionIDLabel = new System.Windows.Forms.Label();
            this.txtSessionID = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.btnClearLogs = new System.Windows.Forms.Button();
            this.grbTradeBot = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnLowPriceKillMode = new System.Windows.Forms.Button();
            this.btnGetInbox = new System.Windows.Forms.Button();
            this.lblTotalStacksInInventory = new System.Windows.Forms.Label();
            this.lblTotalMoneyInInventory = new System.Windows.Forms.Label();
            this.btnDryRun = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnListCards = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusNumPurchased = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusAverageCost = new System.Windows.Forms.ToolStripStatusLabel();
            this.radGFXCard = new System.Windows.Forms.RadioButton();
            this.radParacord = new System.Windows.Forms.RadioButton();
            this.radBTC = new System.Windows.Forms.RadioButton();
            this.radReapIR = new System.Windows.Forms.RadioButton();
            this.grbLogin.SuspendLayout();
            this.grbTradeBot.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbLogin
            // 
            this.grbLogin.Controls.Add(this.AccessTokenLabel);
            this.grbLogin.Controls.Add(this.txtAccessToken);
            this.grbLogin.Controls.Add(this.txtSessionToken);
            this.grbLogin.Controls.Add(this.SessionTokenLabel);
            this.grbLogin.Controls.Add(this.HardwareIDLabel);
            this.grbLogin.Controls.Add(this.txtHWID);
            this.grbLogin.Controls.Add(this.SessionIDLabel);
            this.grbLogin.Controls.Add(this.txtSessionID);
            this.grbLogin.Controls.Add(this.btnLogin);
            this.grbLogin.Controls.Add(this.txtPassword);
            this.grbLogin.Controls.Add(this.PasswordLabel);
            this.grbLogin.Controls.Add(this.UsernameLabel);
            this.grbLogin.Controls.Add(this.txtUsername);
            this.grbLogin.ForeColor = System.Drawing.SystemColors.Control;
            this.grbLogin.Location = new System.Drawing.Point(13, 14);
            this.grbLogin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grbLogin.Name = "grbLogin";
            this.grbLogin.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grbLogin.Size = new System.Drawing.Size(496, 315);
            this.grbLogin.TabIndex = 12;
            this.grbLogin.TabStop = false;
            this.grbLogin.Text = "Login";
            // 
            // AccessTokenLabel
            // 
            this.AccessTokenLabel.AutoSize = true;
            this.AccessTokenLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.AccessTokenLabel.Location = new System.Drawing.Point(173, 34);
            this.AccessTokenLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AccessTokenLabel.Name = "AccessTokenLabel";
            this.AccessTokenLabel.Size = new System.Drawing.Size(79, 13);
            this.AccessTokenLabel.TabIndex = 14;
            this.AccessTokenLabel.Text = "Access Token:";
            // 
            // txtAccessToken
            // 
            this.txtAccessToken.Location = new System.Drawing.Point(176, 57);
            this.txtAccessToken.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAccessToken.Multiline = true;
            this.txtAccessToken.Name = "txtAccessToken";
            this.txtAccessToken.Size = new System.Drawing.Size(306, 80);
            this.txtAccessToken.TabIndex = 13;
            // 
            // txtSessionToken
            // 
            this.txtSessionToken.Location = new System.Drawing.Point(176, 177);
            this.txtSessionToken.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSessionToken.Multiline = true;
            this.txtSessionToken.Name = "txtSessionToken";
            this.txtSessionToken.Size = new System.Drawing.Size(306, 80);
            this.txtSessionToken.TabIndex = 12;
            // 
            // SessionTokenLabel
            // 
            this.SessionTokenLabel.AutoSize = true;
            this.SessionTokenLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.SessionTokenLabel.Location = new System.Drawing.Point(173, 152);
            this.SessionTokenLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SessionTokenLabel.Name = "SessionTokenLabel";
            this.SessionTokenLabel.Size = new System.Drawing.Size(81, 13);
            this.SessionTokenLabel.TabIndex = 11;
            this.SessionTokenLabel.Text = "Session Token:";
            // 
            // HardwareIDLabel
            // 
            this.HardwareIDLabel.AutoSize = true;
            this.HardwareIDLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.HardwareIDLabel.Location = new System.Drawing.Point(20, 34);
            this.HardwareIDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.HardwareIDLabel.Name = "HardwareIDLabel";
            this.HardwareIDLabel.Size = new System.Drawing.Size(98, 13);
            this.HardwareIDLabel.TabIndex = 10;
            this.HardwareIDLabel.Text = "Hardware ID Hash:";
            // 
            // txtHWID
            // 
            this.txtHWID.Location = new System.Drawing.Point(20, 57);
            this.txtHWID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtHWID.Name = "txtHWID";
            this.txtHWID.Size = new System.Drawing.Size(148, 20);
            this.txtHWID.TabIndex = 9;
            // 
            // SessionIDLabel
            // 
            this.SessionIDLabel.AutoSize = true;
            this.SessionIDLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.SessionIDLabel.Location = new System.Drawing.Point(15, 92);
            this.SessionIDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SessionIDLabel.Name = "SessionIDLabel";
            this.SessionIDLabel.Size = new System.Drawing.Size(61, 13);
            this.SessionIDLabel.TabIndex = 8;
            this.SessionIDLabel.Text = "Session ID:";
            // 
            // txtSessionID
            // 
            this.txtSessionID.Location = new System.Drawing.Point(20, 117);
            this.txtSessionID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSessionID.Name = "txtSessionID";
            this.txtSessionID.Size = new System.Drawing.Size(148, 20);
            this.txtSessionID.TabIndex = 7;
            // 
            // btnLogin
            // 
            this.btnLogin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLogin.Location = new System.Drawing.Point(18, 267);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(112, 35);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(20, 237);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(148, 20);
            this.txtPassword.TabIndex = 5;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.PasswordLabel.Location = new System.Drawing.Point(20, 212);
            this.PasswordLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(56, 13);
            this.PasswordLabel.TabIndex = 4;
            this.PasswordLabel.Text = "Password:";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.UsernameLabel.Location = new System.Drawing.Point(20, 152);
            this.UsernameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(58, 13);
            this.UsernameLabel.TabIndex = 3;
            this.UsernameLabel.Text = "Username:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(20, 177);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(148, 20);
            this.txtUsername.TabIndex = 0;
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.SystemColors.Control;
            this.txtLog.Location = new System.Drawing.Point(13, 373);
            this.txtLog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(1246, 268);
            this.txtLog.TabIndex = 14;
            this.txtLog.Text = "";
            this.txtLog.TextChanged += new System.EventHandler(this.txtLog_TextChanged);
            // 
            // btnClearLogs
            // 
            this.btnClearLogs.Location = new System.Drawing.Point(13, 339);
            this.btnClearLogs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClearLogs.Name = "btnClearLogs";
            this.btnClearLogs.Size = new System.Drawing.Size(144, 24);
            this.btnClearLogs.TabIndex = 16;
            this.btnClearLogs.Text = "Clear Logs";
            this.btnClearLogs.UseVisualStyleBackColor = true;
            this.btnClearLogs.Click += new System.EventHandler(this.btnClearLogs_Click);
            // 
            // grbTradeBot
            // 
            this.grbTradeBot.Controls.Add(this.tabControl1);
            this.grbTradeBot.ForeColor = System.Drawing.SystemColors.Control;
            this.grbTradeBot.Location = new System.Drawing.Point(516, 14);
            this.grbTradeBot.Name = "grbTradeBot";
            this.grbTradeBot.Size = new System.Drawing.Size(744, 315);
            this.grbTradeBot.TabIndex = 17;
            this.grbTradeBot.TabStop = false;
            this.grbTradeBot.Text = "Trade Bot";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(6, 19);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(732, 283);
            this.tabControl1.TabIndex = 18;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.radReapIR);
            this.tabPage1.Controls.Add(this.radBTC);
            this.tabPage1.Controls.Add(this.radParacord);
            this.tabPage1.Controls.Add(this.radGFXCard);
            this.tabPage1.Controls.Add(this.btnLowPriceKillMode);
            this.tabPage1.Controls.Add(this.btnGetInbox);
            this.tabPage1.Controls.Add(this.lblTotalStacksInInventory);
            this.tabPage1.Controls.Add(this.lblTotalMoneyInInventory);
            this.tabPage1.Controls.Add(this.btnDryRun);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(724, 257);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Automatic";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnLowPriceKillMode
            // 
            this.btnLowPriceKillMode.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnLowPriceKillMode.Location = new System.Drawing.Point(6, 64);
            this.btnLowPriceKillMode.Name = "btnLowPriceKillMode";
            this.btnLowPriceKillMode.Size = new System.Drawing.Size(159, 23);
            this.btnLowPriceKillMode.TabIndex = 45;
            this.btnLowPriceKillMode.Text = "Low Price Kill Mode";
            this.btnLowPriceKillMode.UseVisualStyleBackColor = true;
            this.btnLowPriceKillMode.Click += new System.EventHandler(this.btnLowPriceKillMode_Click);
            // 
            // btnGetInbox
            // 
            this.btnGetInbox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnGetInbox.Location = new System.Drawing.Point(6, 35);
            this.btnGetInbox.Name = "btnGetInbox";
            this.btnGetInbox.Size = new System.Drawing.Size(159, 23);
            this.btnGetInbox.TabIndex = 44;
            this.btnGetInbox.Text = "Get Inbox";
            this.btnGetInbox.UseVisualStyleBackColor = true;
            this.btnGetInbox.Click += new System.EventHandler(this.btnGetInbox_Click);
            // 
            // lblTotalStacksInInventory
            // 
            this.lblTotalStacksInInventory.AutoSize = true;
            this.lblTotalStacksInInventory.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTotalStacksInInventory.Location = new System.Drawing.Point(534, 19);
            this.lblTotalStacksInInventory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalStacksInInventory.Name = "lblTotalStacksInInventory";
            this.lblTotalStacksInInventory.Size = new System.Drawing.Size(151, 13);
            this.lblTotalStacksInInventory.TabIndex = 43;
            this.lblTotalStacksInInventory.Text = "Total Stacks In Inventory:     #";
            // 
            // lblTotalMoneyInInventory
            // 
            this.lblTotalMoneyInInventory.AutoSize = true;
            this.lblTotalMoneyInInventory.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTotalMoneyInInventory.Location = new System.Drawing.Point(534, 6);
            this.lblTotalMoneyInInventory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalMoneyInInventory.Name = "lblTotalMoneyInInventory";
            this.lblTotalMoneyInInventory.Size = new System.Drawing.Size(150, 13);
            this.lblTotalMoneyInInventory.TabIndex = 42;
            this.lblTotalMoneyInInventory.Text = "Total Money In Inventory:     #";
            // 
            // btnDryRun
            // 
            this.btnDryRun.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDryRun.Location = new System.Drawing.Point(6, 6);
            this.btnDryRun.Name = "btnDryRun";
            this.btnDryRun.Size = new System.Drawing.Size(159, 23);
            this.btnDryRun.TabIndex = 19;
            this.btnDryRun.Text = "Perform Dry Run";
            this.btnDryRun.UseVisualStyleBackColor = true;
            this.btnDryRun.Click += new System.EventHandler(this.btnDryRun_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnListCards);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(724, 257);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Manual";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnListCards
            // 
            this.btnListCards.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnListCards.Location = new System.Drawing.Point(5, 6);
            this.btnListCards.Name = "btnListCards";
            this.btnListCards.Size = new System.Drawing.Size(159, 23);
            this.btnListCards.TabIndex = 45;
            this.btnListCards.Text = "List All Labs Cards";
            this.btnListCards.UseVisualStyleBackColor = true;
            this.btnListCards.Click += new System.EventHandler(this.btnListCards_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusNumPurchased,
            this.statusAverageCost});
            this.statusStrip.Location = new System.Drawing.Point(0, 646);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1272, 22);
            this.statusStrip.TabIndex = 18;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusNumPurchased
            // 
            this.statusNumPurchased.BackColor = System.Drawing.SystemColors.Control;
            this.statusNumPurchased.Name = "statusNumPurchased";
            this.statusNumPurchased.Size = new System.Drawing.Size(132, 17);
            this.statusNumPurchased.Text = "Number Purchased:  ##";
            // 
            // statusAverageCost
            // 
            this.statusAverageCost.BackColor = System.Drawing.SystemColors.Control;
            this.statusAverageCost.Name = "statusAverageCost";
            this.statusAverageCost.Size = new System.Drawing.Size(100, 17);
            this.statusAverageCost.Text = "Average Cost:  ##";
            // 
            // radGFXCard
            // 
            this.radGFXCard.AutoSize = true;
            this.radGFXCard.Checked = true;
            this.radGFXCard.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.radGFXCard.Location = new System.Drawing.Point(171, 67);
            this.radGFXCard.Name = "radGFXCard";
            this.radGFXCard.Size = new System.Drawing.Size(92, 17);
            this.radGFXCard.TabIndex = 46;
            this.radGFXCard.Text = "Graphics Card";
            this.radGFXCard.UseVisualStyleBackColor = true;
            this.radGFXCard.CheckedChanged += new System.EventHandler(this.radGFXCard_CheckedChanged);
            // 
            // radParacord
            // 
            this.radParacord.AutoSize = true;
            this.radParacord.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.radParacord.Location = new System.Drawing.Point(269, 67);
            this.radParacord.Name = "radParacord";
            this.radParacord.Size = new System.Drawing.Size(68, 17);
            this.radParacord.TabIndex = 47;
            this.radParacord.Text = "Paracord";
            this.radParacord.UseVisualStyleBackColor = true;
            this.radParacord.CheckedChanged += new System.EventHandler(this.radParacord_CheckedChanged);
            // 
            // radBTC
            // 
            this.radBTC.AutoSize = true;
            this.radBTC.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.radBTC.Location = new System.Drawing.Point(343, 67);
            this.radBTC.Name = "radBTC";
            this.radBTC.Size = new System.Drawing.Size(57, 17);
            this.radBTC.TabIndex = 48;
            this.radBTC.Text = "Bitcoin";
            this.radBTC.UseVisualStyleBackColor = true;
            this.radBTC.CheckedChanged += new System.EventHandler(this.radBTC_CheckedChanged);
            // 
            // radReapIR
            // 
            this.radReapIR.AutoSize = true;
            this.radReapIR.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.radReapIR.Location = new System.Drawing.Point(406, 67);
            this.radReapIR.Name = "radReapIR";
            this.radReapIR.Size = new System.Drawing.Size(65, 17);
            this.radReapIR.TabIndex = 49;
            this.radReapIR.Text = "Reap-IR";
            this.radReapIR.UseVisualStyleBackColor = true;
            this.radReapIR.CheckedChanged += new System.EventHandler(this.radReapIR_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1272, 668);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.grbTradeBot);
            this.Controls.Add(this.btnClearLogs);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.grbLogin);
            this.Name = "MainForm";
            this.Text = "requester_rebase";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.grbLogin.ResumeLayout(false);
            this.grbLogin.PerformLayout();
            this.grbTradeBot.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.GroupBox grbLogin;
        private System.Windows.Forms.Label HardwareIDLabel;
        public System.Windows.Forms.TextBox txtHWID;
        private System.Windows.Forms.Label SessionIDLabel;
        public System.Windows.Forms.TextBox txtSessionID;
        public System.Windows.Forms.Button btnLogin;
        public System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label UsernameLabel;
        public System.Windows.Forms.TextBox txtUsername;
        public System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.Button btnClearLogs;
        public System.Windows.Forms.GroupBox grbTradeBot;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label AccessTokenLabel;
        public System.Windows.Forms.TextBox txtAccessToken;
        public System.Windows.Forms.TextBox txtSessionToken;
        private System.Windows.Forms.Label SessionTokenLabel;
        public System.Windows.Forms.StatusStrip statusStrip;
        public System.Windows.Forms.ToolStripStatusLabel statusNumPurchased;
        public System.Windows.Forms.Button btnDryRun;
        public System.Windows.Forms.Label lblTotalStacksInInventory;
        public System.Windows.Forms.Label lblTotalMoneyInInventory;
        public System.Windows.Forms.ToolStripStatusLabel statusAverageCost;
        public System.Windows.Forms.Button btnGetInbox;
        public System.Windows.Forms.Button btnListCards;
        public System.Windows.Forms.Button btnLowPriceKillMode;
        private System.Windows.Forms.RadioButton radBTC;
        private System.Windows.Forms.RadioButton radParacord;
        private System.Windows.Forms.RadioButton radGFXCard;
        private System.Windows.Forms.RadioButton radReapIR;
    }
}

