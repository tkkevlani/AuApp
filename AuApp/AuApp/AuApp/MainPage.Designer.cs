namespace AuApp
{
    partial class MainPage
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Org_tab = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomerTab = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.PaymentTab = new System.Windows.Forms.ToolStripMenuItem();
            this.ReportsTab = new System.Windows.Forms.ToolStripMenuItem();
            this.StocksTab = new System.Windows.Forms.ToolStripMenuItem();
            this.UsersTab = new System.Windows.Forms.ToolStripMenuItem();
            this.AuditTab = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.menuStrip1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1681, 784);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 111);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1675, 670);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Results";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 18);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1669, 649);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 46);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1675, 65);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filters";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(690, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(327, 30);
            this.textBox1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1023, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 33);
            this.button1.TabIndex = 2;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Name",
            "Phone",
            "Mobile",
            "License",
            "cNIC"});
            this.comboBox1.Location = new System.Drawing.Point(392, 18);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(291, 33);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.Text = "Select...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(345, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "By:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Org_tab,
            this.CustomerTab,
            this.PaymentTab,
            this.ReportsTab,
            this.StocksTab,
            this.UsersTab,
            this.AuditTab});
            this.menuStrip1.Location = new System.Drawing.Point(3, 18);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1675, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Org_tab
            // 
            this.Org_tab.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem2});
            this.Org_tab.Image = global::AuApp.Properties.Resources.org;
            this.Org_tab.Name = "Org_tab";
            this.Org_tab.Size = new System.Drawing.Size(127, 24);
            this.Org_tab.Text = "Organization";
            this.Org_tab.Visible = false;
            // 
            // createToolStripMenuItem2
            // 
            this.createToolStripMenuItem2.Image = global::AuApp.Properties.Resources.if_plus_1646001;
            this.createToolStripMenuItem2.Name = "createToolStripMenuItem2";
            this.createToolStripMenuItem2.Size = new System.Drawing.Size(181, 26);
            this.createToolStripMenuItem2.Text = "Create";
            this.createToolStripMenuItem2.Click += new System.EventHandler(this.createToolStripMenuItem2_Click);
            // 
            // CustomerTab
            // 
            this.CustomerTab.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem1});
            this.CustomerTab.Image = global::AuApp.Properties.Resources.customer;
            this.CustomerTab.Name = "CustomerTab";
            this.CustomerTab.Size = new System.Drawing.Size(104, 24);
            this.CustomerTab.Text = "Customer";
            this.CustomerTab.Click += new System.EventHandler(this.CustomerTab_Click);
            // 
            // createToolStripMenuItem1
            // 
            this.createToolStripMenuItem1.Image = global::AuApp.Properties.Resources.if_plus_1646001;
            this.createToolStripMenuItem1.Name = "createToolStripMenuItem1";
            this.createToolStripMenuItem1.Size = new System.Drawing.Size(181, 26);
            this.createToolStripMenuItem1.Text = "Create";
            this.createToolStripMenuItem1.Click += new System.EventHandler(this.createToolStripMenuItem1_Click);
            // 
            // PaymentTab
            // 
            this.PaymentTab.Image = global::AuApp.Properties.Resources.payment;
            this.PaymentTab.Name = "PaymentTab";
            this.PaymentTab.Size = new System.Drawing.Size(98, 24);
            this.PaymentTab.Text = "Payment";
            // 
            // ReportsTab
            // 
            this.ReportsTab.Image = global::AuApp.Properties.Resources.report;
            this.ReportsTab.Name = "ReportsTab";
            this.ReportsTab.Size = new System.Drawing.Size(92, 24);
            this.ReportsTab.Text = "Reports";
            // 
            // StocksTab
            // 
            this.StocksTab.Image = global::AuApp.Properties.Resources.stock;
            this.StocksTab.Name = "StocksTab";
            this.StocksTab.Size = new System.Drawing.Size(77, 24);
            this.StocksTab.Text = "Stock";
            this.StocksTab.Click += new System.EventHandler(this.StocksTab_Click);
            // 
            // UsersTab
            // 
            this.UsersTab.Image = global::AuApp.Properties.Resources.customer_1;
            this.UsersTab.Name = "UsersTab";
            this.UsersTab.Size = new System.Drawing.Size(76, 24);
            this.UsersTab.Text = "Users";
            this.UsersTab.Click += new System.EventHandler(this.UsersTab_Click);
            // 
            // AuditTab
            // 
            this.AuditTab.Image = global::AuApp.Properties.Resources.if_SEO_usability_audit_search__969250;
            this.AuditTab.Name = "AuditTab";
            this.AuditTab.Size = new System.Drawing.Size(77, 24);
            this.AuditTab.Text = "Audit";
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1681, 784);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainPage";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainPage_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainPage_FormClosed);
            this.Load += new System.EventHandler(this.MainPage_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem CustomerTab;
        private System.Windows.Forms.ToolStripMenuItem PaymentTab;
        private System.Windows.Forms.ToolStripMenuItem ReportsTab;
        private System.Windows.Forms.ToolStripMenuItem StocksTab;
        private System.Windows.Forms.ToolStripMenuItem UsersTab;
        private System.Windows.Forms.ToolStripMenuItem AuditTab;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem Org_tab;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem2;
    }
}