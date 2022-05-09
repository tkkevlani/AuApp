namespace AuApp.Stock
{
    partial class Stock_Frm
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
            this.StockInfo_GP = new System.Windows.Forms.GroupBox();
            this.year_Dtp = new System.Windows.Forms.DateTimePicker();
            this.condition_cmbo = new System.Windows.Forms.ComboBox();
            this.VehicleType_Cmbo = new System.Windows.Forms.ComboBox();
            this.Price_txt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Chasis_txt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Engine_txt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Model_txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Brand_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Userid_chk = new System.Windows.Forms.CheckBox();
            this.Save_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Search_GP = new System.Windows.Forms.GroupBox();
            this.Search_btn = new System.Windows.Forms.Button();
            this.Search_txt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.addStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.Results_Gp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Result_grd)).BeginInit();
            this.StockInfo_GP.SuspendLayout();
            this.Search_GP.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Results_Gp);
            this.panel1.Controls.Add(this.StockInfo_GP);
            this.panel1.Controls.Add(this.Search_GP);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1188, 775);
            this.panel1.TabIndex = 0;
            // 
            // Results_Gp
            // 
            this.Results_Gp.Controls.Add(this.Result_grd);
            this.Results_Gp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Results_Gp.Location = new System.Drawing.Point(0, 249);
            this.Results_Gp.Name = "Results_Gp";
            this.Results_Gp.Size = new System.Drawing.Size(1188, 526);
            this.Results_Gp.TabIndex = 8;
            this.Results_Gp.TabStop = false;
            this.Results_Gp.Text = "Available Stock";
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
            this.Result_grd.Size = new System.Drawing.Size(1182, 505);
            this.Result_grd.TabIndex = 0;
            // 
            // StockInfo_GP
            // 
            this.StockInfo_GP.Controls.Add(this.year_Dtp);
            this.StockInfo_GP.Controls.Add(this.condition_cmbo);
            this.StockInfo_GP.Controls.Add(this.VehicleType_Cmbo);
            this.StockInfo_GP.Controls.Add(this.Price_txt);
            this.StockInfo_GP.Controls.Add(this.label6);
            this.StockInfo_GP.Controls.Add(this.label7);
            this.StockInfo_GP.Controls.Add(this.Chasis_txt);
            this.StockInfo_GP.Controls.Add(this.label8);
            this.StockInfo_GP.Controls.Add(this.Engine_txt);
            this.StockInfo_GP.Controls.Add(this.label9);
            this.StockInfo_GP.Controls.Add(this.label5);
            this.StockInfo_GP.Controls.Add(this.Model_txt);
            this.StockInfo_GP.Controls.Add(this.label3);
            this.StockInfo_GP.Controls.Add(this.Brand_txt);
            this.StockInfo_GP.Controls.Add(this.label2);
            this.StockInfo_GP.Controls.Add(this.Userid_chk);
            this.StockInfo_GP.Controls.Add(this.Save_btn);
            this.StockInfo_GP.Controls.Add(this.label1);
            this.StockInfo_GP.Dock = System.Windows.Forms.DockStyle.Top;
            this.StockInfo_GP.Location = new System.Drawing.Point(0, 85);
            this.StockInfo_GP.Name = "StockInfo_GP";
            this.StockInfo_GP.Size = new System.Drawing.Size(1188, 164);
            this.StockInfo_GP.TabIndex = 7;
            this.StockInfo_GP.TabStop = false;
            this.StockInfo_GP.Text = "Add New";
            // 
            // year_Dtp
            // 
            this.year_Dtp.CustomFormat = "yyyy";
            this.year_Dtp.Location = new System.Drawing.Point(210, 105);
            this.year_Dtp.Name = "year_Dtp";
            this.year_Dtp.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.year_Dtp.ShowUpDown = true;
            this.year_Dtp.Size = new System.Drawing.Size(364, 22);
            this.year_Dtp.TabIndex = 5;
            this.year_Dtp.ValueChanged += new System.EventHandler(this.year_Dtp_ValueChanged);
            // 
            // condition_cmbo
            // 
            this.condition_cmbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.condition_cmbo.FormattingEnabled = true;
            this.condition_cmbo.Location = new System.Drawing.Point(702, 78);
            this.condition_cmbo.Name = "condition_cmbo";
            this.condition_cmbo.Size = new System.Drawing.Size(365, 24);
            this.condition_cmbo.TabIndex = 8;
            this.condition_cmbo.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // VehicleType_Cmbo
            // 
            this.VehicleType_Cmbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VehicleType_Cmbo.FormattingEnabled = true;
            this.VehicleType_Cmbo.Location = new System.Drawing.Point(209, 23);
            this.VehicleType_Cmbo.Name = "VehicleType_Cmbo";
            this.VehicleType_Cmbo.Size = new System.Drawing.Size(365, 24);
            this.VehicleType_Cmbo.TabIndex = 2;
            // 
            // Price_txt
            // 
            this.Price_txt.Location = new System.Drawing.Point(702, 106);
            this.Price_txt.Name = "Price_txt";
            this.Price_txt.Size = new System.Drawing.Size(365, 22);
            this.Price_txt.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(621, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 17);
            this.label6.TabIndex = 29;
            this.label6.Text = "Base price";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(629, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 17);
            this.label7.TabIndex = 27;
            this.label7.Text = "Condition";
            // 
            // Chasis_txt
            // 
            this.Chasis_txt.Location = new System.Drawing.Point(702, 50);
            this.Chasis_txt.Name = "Chasis_txt";
            this.Chasis_txt.Size = new System.Drawing.Size(365, 22);
            this.Chasis_txt.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(624, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 17);
            this.label8.TabIndex = 25;
            this.label8.Text = "Chasis no";
            // 
            // Engine_txt
            // 
            this.Engine_txt.Location = new System.Drawing.Point(702, 22);
            this.Engine_txt.Name = "Engine_txt";
            this.Engine_txt.Size = new System.Drawing.Size(365, 22);
            this.Engine_txt.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(622, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 17);
            this.label9.TabIndex = 23;
            this.label9.Text = "Engine no";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(165, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 17);
            this.label5.TabIndex = 21;
            this.label5.Text = "Year";
            // 
            // Model_txt
            // 
            this.Model_txt.Location = new System.Drawing.Point(209, 80);
            this.Model_txt.Name = "Model_txt";
            this.Model_txt.Size = new System.Drawing.Size(365, 22);
            this.Model_txt.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(157, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 19;
            this.label3.Text = "Model";
            // 
            // Brand_txt
            // 
            this.Brand_txt.Location = new System.Drawing.Point(209, 52);
            this.Brand_txt.Name = "Brand_txt";
            this.Brand_txt.Size = new System.Drawing.Size(365, 22);
            this.Brand_txt.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(157, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "Brand";
            // 
            // Userid_chk
            // 
            this.Userid_chk.AutoSize = true;
            this.Userid_chk.Location = new System.Drawing.Point(968, 138);
            this.Userid_chk.Name = "Userid_chk";
            this.Userid_chk.Size = new System.Drawing.Size(18, 17);
            this.Userid_chk.TabIndex = 15;
            this.Userid_chk.UseVisualStyleBackColor = true;
            this.Userid_chk.Visible = false;
            // 
            // Save_btn
            // 
            this.Save_btn.Location = new System.Drawing.Point(992, 134);
            this.Save_btn.Name = "Save_btn";
            this.Save_btn.Size = new System.Drawing.Size(75, 23);
            this.Save_btn.TabIndex = 10;
            this.Save_btn.Text = "Save";
            this.Save_btn.UseVisualStyleBackColor = true;
            this.Save_btn.Click += new System.EventHandler(this.Save_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(113, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Vehicle type";
            // 
            // Search_GP
            // 
            this.Search_GP.Controls.Add(this.Search_btn);
            this.Search_GP.Controls.Add(this.Search_txt);
            this.Search_GP.Controls.Add(this.label4);
            this.Search_GP.Dock = System.Windows.Forms.DockStyle.Top;
            this.Search_GP.Location = new System.Drawing.Point(0, 28);
            this.Search_GP.Name = "Search_GP";
            this.Search_GP.Size = new System.Drawing.Size(1188, 57);
            this.Search_GP.TabIndex = 4;
            this.Search_GP.TabStop = false;
            this.Search_GP.Text = "Search";
            // 
            // Search_btn
            // 
            this.Search_btn.Location = new System.Drawing.Point(775, 21);
            this.Search_btn.Name = "Search_btn";
            this.Search_btn.Size = new System.Drawing.Size(66, 23);
            this.Search_btn.TabIndex = 1;
            this.Search_btn.Text = "Search";
            this.Search_btn.UseVisualStyleBackColor = true;
            // 
            // Search_txt
            // 
            this.Search_txt.Location = new System.Drawing.Point(380, 22);
            this.Search_txt.Name = "Search_txt";
            this.Search_txt.Size = new System.Drawing.Size(389, 22);
            this.Search_txt.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(300, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 17);
            this.label4.TabIndex = 20;
            this.label4.Text = "Engine No";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addStockToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1188, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // addStockToolStripMenuItem
            // 
            this.addStockToolStripMenuItem.Image = global::AuApp.Properties.Resources.add;
            this.addStockToolStripMenuItem.Name = "addStockToolStripMenuItem";
            this.addStockToolStripMenuItem.Size = new System.Drawing.Size(107, 24);
            this.addStockToolStripMenuItem.Text = "Add stock";
            this.addStockToolStripMenuItem.Click += new System.EventHandler(this.addStockToolStripMenuItem_Click);
            // 
            // Stock_Frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 775);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Stock_Frm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Information";
            this.Load += new System.EventHandler(this.Stock_Frm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.Results_Gp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Result_grd)).EndInit();
            this.StockInfo_GP.ResumeLayout(false);
            this.StockInfo_GP.PerformLayout();
            this.Search_GP.ResumeLayout(false);
            this.Search_GP.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.GroupBox Search_GP;
        private System.Windows.Forms.Button Search_btn;
        private System.Windows.Forms.TextBox Search_txt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox StockInfo_GP;
        private System.Windows.Forms.CheckBox Userid_chk;
        private System.Windows.Forms.Button Save_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox Results_Gp;
        private System.Windows.Forms.DataGridView Result_grd;
        private System.Windows.Forms.TextBox Price_txt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Chasis_txt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Engine_txt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Model_txt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Brand_txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox VehicleType_Cmbo;
        private System.Windows.Forms.ComboBox condition_cmbo;
        private System.Windows.Forms.ToolStripMenuItem addStockToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker year_Dtp;
    }
}