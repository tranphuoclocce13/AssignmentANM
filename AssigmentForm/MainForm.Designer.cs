namespace AssigmentForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tasksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transferToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nornalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.useEncryptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rSAEncryptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.portsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewPortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePortToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.transferPortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chatPortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbView = new System.Windows.Forms.TextBox();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lbStatus = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tasksToolStripMenuItem,
            this.transferToolStripMenuItem,
            this.portsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(466, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tasksToolStripMenuItem
            // 
            this.tasksToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newConnectionToolStripMenuItem,
            this.disconnectToolStripMenuItem,
            this.clearTextToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.tasksToolStripMenuItem.Name = "tasksToolStripMenuItem";
            this.tasksToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.tasksToolStripMenuItem.Text = "Tasks";
            // 
            // newConnectionToolStripMenuItem
            // 
            this.newConnectionToolStripMenuItem.Name = "newConnectionToolStripMenuItem";
            this.newConnectionToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.newConnectionToolStripMenuItem.Text = "New Connection";
            this.newConnectionToolStripMenuItem.Click += new System.EventHandler(this.newConnectionToolStripMenuItem_Click);
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.disconnectToolStripMenuItem.Text = "Disconnect";
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // clearTextToolStripMenuItem
            // 
            this.clearTextToolStripMenuItem.Name = "clearTextToolStripMenuItem";
            this.clearTextToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.clearTextToolStripMenuItem.Text = "Clear Text";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // transferToolStripMenuItem
            // 
            this.transferToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nornalToolStripMenuItem,
            this.useEncryptionToolStripMenuItem});
            this.transferToolStripMenuItem.Name = "transferToolStripMenuItem";
            this.transferToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.transferToolStripMenuItem.Text = "Transfer File";
            // 
            // nornalToolStripMenuItem
            // 
            this.nornalToolStripMenuItem.Name = "nornalToolStripMenuItem";
            this.nornalToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.nornalToolStripMenuItem.Text = "Nornal";
            this.nornalToolStripMenuItem.Click += new System.EventHandler(this.nornalToolStripMenuItem_Click);
            // 
            // useEncryptionToolStripMenuItem
            // 
            this.useEncryptionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rSAEncryptionToolStripMenuItem,
            this.dESToolStripMenuItem,
            this.aESToolStripMenuItem});
            this.useEncryptionToolStripMenuItem.Name = "useEncryptionToolStripMenuItem";
            this.useEncryptionToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.useEncryptionToolStripMenuItem.Text = "Use Encryption";
            // 
            // rSAEncryptionToolStripMenuItem
            // 
            this.rSAEncryptionToolStripMenuItem.Name = "rSAEncryptionToolStripMenuItem";
            this.rSAEncryptionToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.rSAEncryptionToolStripMenuItem.Text = "RSA ";
            // 
            // dESToolStripMenuItem
            // 
            this.dESToolStripMenuItem.Name = "dESToolStripMenuItem";
            this.dESToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.dESToolStripMenuItem.Text = "DES";
            // 
            // aESToolStripMenuItem
            // 
            this.aESToolStripMenuItem.Name = "aESToolStripMenuItem";
            this.aESToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.aESToolStripMenuItem.Text = "AES";
            // 
            // portsToolStripMenuItem
            // 
            this.portsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewPortToolStripMenuItem,
            this.changePortToolStripMenuItem1});
            this.portsToolStripMenuItem.Name = "portsToolStripMenuItem";
            this.portsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.portsToolStripMenuItem.Text = "Ports";
            // 
            // viewPortToolStripMenuItem
            // 
            this.viewPortToolStripMenuItem.Name = "viewPortToolStripMenuItem";
            this.viewPortToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.viewPortToolStripMenuItem.Text = "ViewPort";
            this.viewPortToolStripMenuItem.Click += new System.EventHandler(this.viewPortToolStripMenuItem_Click);
            // 
            // changePortToolStripMenuItem1
            // 
            this.changePortToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.transferPortToolStripMenuItem,
            this.chatPortToolStripMenuItem});
            this.changePortToolStripMenuItem1.Name = "changePortToolStripMenuItem1";
            this.changePortToolStripMenuItem1.Size = new System.Drawing.Size(140, 22);
            this.changePortToolStripMenuItem1.Text = "Change Port";
            // 
            // transferPortToolStripMenuItem
            // 
            this.transferPortToolStripMenuItem.Name = "transferPortToolStripMenuItem";
            this.transferPortToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.transferPortToolStripMenuItem.Text = "Transfer Port";
            this.transferPortToolStripMenuItem.Click += new System.EventHandler(this.transferPortToolStripMenuItem_Click);
            // 
            // chatPortToolStripMenuItem
            // 
            this.chatPortToolStripMenuItem.Name = "chatPortToolStripMenuItem";
            this.chatPortToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.chatPortToolStripMenuItem.Text = "Chat Port";
            this.chatPortToolStripMenuItem.Click += new System.EventHandler(this.chatPortToolStripMenuItem_Click);
            // 
            // tbView
            // 
            this.tbView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbView.BackColor = System.Drawing.SystemColors.Window;
            this.tbView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbView.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbView.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbView.Location = new System.Drawing.Point(0, 28);
            this.tbView.Multiline = true;
            this.tbView.Name = "tbView";
            this.tbView.ReadOnly = true;
            this.tbView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbView.ShortcutsEnabled = false;
            this.tbView.Size = new System.Drawing.Size(466, 275);
            this.tbView.TabIndex = 2;
            // 
            // tbMessage
            // 
            this.tbMessage.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMessage.Location = new System.Drawing.Point(0, 310);
            this.tbMessage.Multiline = true;
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbMessage.Size = new System.Drawing.Size(413, 47);
            this.tbMessage.TabIndex = 3;
            this.tbMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbMessage_KeyDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(420, 310);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(46, 47);
            this.button1.TabIndex = 4;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbStatus
            // 
            this.lbStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatus.Location = new System.Drawing.Point(0, 366);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(466, 13);
            this.lbStatus.TabIndex = 5;
            this.lbStatus.Text = "Waiting...";
            this.lbStatus.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 379);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbMessage);
            this.Controls.Add(this.tbView);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Messenger";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tasksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newConnectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transferToolStripMenuItem;
        private System.Windows.Forms.TextBox tbView;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem portsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewPortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePortToolStripMenuItem1;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.ToolStripMenuItem nornalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem useEncryptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rSAEncryptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transferPortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chatPortToolStripMenuItem;
    }
}

