namespace AuApp.Login
{
    partial class Users_frm
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
            this.Results_Gp = new System.Windows.Forms.GroupBox();
            this.Result_grd = new System.Windows.Forms.DataGridView();
            this.CreateUsr_GP = new System.Windows.Forms.GroupBox();
            this.Userid_chk = new System.Windows.Forms.CheckBox();
            this.Save_btn = new System.Windows.Forms.Button();
            this.Password_txt = new System.Windows.Forms.TextBox();
            this.User_txt = new System.Windows.Forms.TextBox();
            this.Role_cmbo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Search_GP = new System.Windows.Forms.GroupBox();
            this.Search_btn = new System.Windows.Forms.Button();
            this.Search_txt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.Results_Gp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Result_grd)).BeginInit();
            this.CreateUsr_GP.SuspendLayout();
            this.Search_GP.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Results_Gp);
            this.panel1.Controls.Add(this.CreateUsr_GP);
            this.panel1.Controls.Add(this.Search_GP);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1132, 655);
            this.panel1.TabIndex = 0;
            // 
            // Results_Gp
            // 
            this.Results_Gp.Controls.Add(this.Result_grd);
            this.Results_Gp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Results_Gp.Location = new System.Drawing.Point(0, 270);
            this.Results_Gp.Name = "Results_Gp";
            this.Results_Gp.Size = new System.Drawing.Size(1132, 385);
            this.Results_Gp.TabIndex = 3;
            this.Results_Gp.TabStop = false;
            this.Results_Gp.Text = "All Users";
            // 
            // Result_grd
            // 
            this.Result_grd.AllowUserToAddRows = false;
            this.Result_grd.AllowUserToDeleteRows = false;
            this.Result_grd.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Result_grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Result_grd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Result_grd.Location = new System.Drawing.Point(3, 18);
            this.Result_grd.Name = "Result_grd";
            this.Result_grd.ReadOnly = true;
            this.Result_grd.RowTemplate.Height = 24;
            this.Result_grd.Size = new System.Drawing.Size(1126, 364);
            this.Result_grd.TabIndex = 0;
            this.Result_grd.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Result_grd_CellContentClick);
            this.Result_grd.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Result_grd_CellDoubleClick);
            // 
            // CreateUsr_GP
            // 
            this.CreateUsr_GP.Controls.Add(this.Userid_chk);
            this.CreateUsr_GP.Controls.Add(this.Save_btn);
            this.CreateUsr_GP.Controls.Add(this.Password_txt);
            this.CreateUsr_GP.Controls.Add(this.User_txt);
            this.CreateUsr_GP.Controls.Add(this.Role_cmbo);
            this.CreateUsr_GP.Controls.Add(this.label3);
            this.CreateUsr_GP.Controls.Add(this.label2);
            this.CreateUsr_GP.Controls.Add(this.label1);
            this.CreateUsr_GP.Dock = System.Windows.Forms.DockStyle.Top;
            this.CreateUsr_GP.Location = new System.Drawing.Point(0, 119);
            this.CreateUsr_GP.Name = "CreateUsr_GP";
            this.CreateUsr_GP.Size = new System.Drawing.Size(1132, 151);
            this.CreateUsr_GP.TabIndex = 2;
            this.CreateUsr_GP.TabStop = false;
            this.CreateUsr_GP.Text = "User info";
            this.CreateUsr_GP.Enter += new System.EventHandler(this.CreateUsr_GP_Enter);
            // 
            // Userid_chk
            // 
            this.Userid_chk.AutoSize = true;
            this.Userid_chk.Location = new System.Drawing.Point(622, 115);
            this.Userid_chk.Name = "Userid_chk";
            this.Userid_chk.Size = new System.Drawing.Size(18, 17);
            this.Userid_chk.TabIndex = 15;
            this.Userid_chk.UseVisualStyleBackColor = true;
            this.Userid_chk.Visible = false;
            // 
            // Save_btn
            // 
            this.Save_btn.Location = new System.Drawing.Point(646, 111);
            this.Save_btn.Name = "Save_btn";
            this.Save_btn.Size = new System.Drawing.Size(75, 23);
            this.Save_btn.TabIndex = 5;
            this.Save_btn.Text = "Save";
            this.Save_btn.UseVisualStyleBackColor = true;
            this.Save_btn.Click += new System.EventHandler(this.Save_btn_Click);
            // 
            // Password_txt
            // 
            this.Password_txt.Location = new System.Drawing.Point(356, 83);
            this.Password_txt.Name = "Password_txt";
            this.Password_txt.PasswordChar = '*';
            this.Password_txt.Size = new System.Drawing.Size(365, 22);
            this.Password_txt.TabIndex = 4;
            // 
            // User_txt
            // 
            this.User_txt.Location = new System.Drawing.Point(356, 19);
            this.User_txt.Name = "User_txt";
            this.User_txt.Size = new System.Drawing.Size(365, 22);
            this.User_txt.TabIndex = 2;
            // 
            // Role_cmbo
            // 
            this.Role_cmbo.FormattingEnabled = true;
            this.Role_cmbo.Location = new System.Drawing.Point(356, 52);
            this.Role_cmbo.Name = "Role_cmbo";
            this.Role_cmbo.Size = new System.Drawing.Size(365, 24);
            this.Role_cmbo.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(199, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "Temporary Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(304, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Role";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(268, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Username";
            // 
            // Search_GP
            // 
            this.Search_GP.Controls.Add(this.Search_btn);
            this.Search_GP.Controls.Add(this.Search_txt);
            this.Search_GP.Controls.Add(this.label4);
            this.Search_GP.Dock = System.Windows.Forms.DockStyle.Top;
            this.Search_GP.Location = new System.Drawing.Point(0, 56);
            this.Search_GP.Name = "Search_GP";
            this.Search_GP.Size = new System.Drawing.Size(1132, 63);
            this.Search_GP.TabIndex = 1;
            this.Search_GP.TabStop = false;
            this.Search_GP.Text = "Search";
            this.Search_GP.Enter += new System.EventHandler(this.Search_GP_Enter);
            // 
            // Search_btn
            // 
            this.Search_btn.Location = new System.Drawing.Point(656, 24);
            this.Search_btn.Name = "Search_btn";
            this.Search_btn.Size = new System.Drawing.Size(66, 23);
            this.Search_btn.TabIndex = 1;
            this.Search_btn.Text = "Search";
            this.Search_btn.UseVisualStyleBackColor = true;
            this.Search_btn.Click += new System.EventHandler(this.Search_btn_Click);
            // 
            // Search_txt
            // 
            this.Search_txt.Location = new System.Drawing.Point(419, 25);
            this.Search_txt.Name = "Search_txt";
            this.Search_txt.Size = new System.Drawing.Size(231, 22);
            this.Search_txt.TabIndex = 0;
            this.Search_txt.TextChanged += new System.EventHandler(this.Search_txt_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(334, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 17);
            this.label4.TabIndex = 20;
            this.label4.Text = "Username";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.menuStrip1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1132, 56);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 18);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1126, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Image = global::AuApp.Properties.Resources.addUserimages;
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(69, 24);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // Users_frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 655);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Users_frm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Information";
            this.Load += new System.EventHandler(this.Users_frm_Load);
            this.panel1.ResumeLayout(false);
            this.Results_Gp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Result_grd)).EndInit();
            this.CreateUsr_GP.ResumeLayout(false);
            this.CreateUsr_GP.PerformLayout();
            this.Search_GP.ResumeLayout(false);
            this.Search_GP.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox Results_Gp;
        private System.Windows.Forms.DataGridView Result_grd;
        private System.Windows.Forms.GroupBox CreateUsr_GP;
        private System.Windows.Forms.Button Save_btn;
        private System.Windows.Forms.TextBox Password_txt;
        private System.Windows.Forms.TextBox User_txt;
        private System.Windows.Forms.ComboBox Role_cmbo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox Search_GP;
        private System.Windows.Forms.Button Search_btn;
        private System.Windows.Forms.TextBox Search_txt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.CheckBox Userid_chk;
    }
}