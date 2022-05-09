namespace LicenseUtility
{
    partial class LicenseForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_server = new System.Windows.Forms.TextBox();
            this.txt_database = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_userid = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_password = new System.Windows.Forms.MaskedTextBox();
            this.btn_connect = new System.Windows.Forms.Button();
            this.btn_disconnect = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_status = new System.Windows.Forms.Label();
            this.btn_check = new System.Windows.Forms.Button();
            this.btn_newlicense = new System.Windows.Forms.Button();
            this.btn_updatelicense = new System.Windows.Forms.Button();
            this.btn_searchlicense = new System.Windows.Forms.Button();
            this.gbx = new System.Windows.Forms.GroupBox();
            this.btn_saveToFile = new System.Windows.Forms.Button();
            this.licenseGrid = new System.Windows.Forms.DataGridView();
            this.btn_validate = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btn_activateFromFile = new System.Windows.Forms.Button();
            this.gbx.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.licenseGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(200, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Database";
            // 
            // txt_server
            // 
            this.txt_server.Location = new System.Drawing.Point(56, 6);
            this.txt_server.Name = "txt_server";
            this.txt_server.Size = new System.Drawing.Size(138, 20);
            this.txt_server.TabIndex = 1;
            this.txt_server.Text = "localhost";
            // 
            // txt_database
            // 
            this.txt_database.Location = new System.Drawing.Point(259, 6);
            this.txt_database.Name = "txt_database";
            this.txt_database.Size = new System.Drawing.Size(138, 20);
            this.txt_database.TabIndex = 1;
            this.txt_database.Text = "audb";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(403, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "User Id";
            // 
            // txt_userid
            // 
            this.txt_userid.Location = new System.Drawing.Point(450, 6);
            this.txt_userid.Name = "txt_userid";
            this.txt_userid.Size = new System.Drawing.Size(138, 20);
            this.txt_userid.TabIndex = 1;
            this.txt_userid.Text = "root";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(594, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Password";
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(653, 6);
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar = '*';
            this.txt_password.Size = new System.Drawing.Size(138, 20);
            this.txt_password.TabIndex = 2;
            this.txt_password.Text = "2qaz@QAZ2qaz";
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(432, 32);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(75, 23);
            this.btn_connect.TabIndex = 3;
            this.btn_connect.Text = "Connect";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // btn_disconnect
            // 
            this.btn_disconnect.Location = new System.Drawing.Point(513, 32);
            this.btn_disconnect.Name = "btn_disconnect";
            this.btn_disconnect.Size = new System.Drawing.Size(75, 23);
            this.btn_disconnect.TabIndex = 3;
            this.btn_disconnect.Text = "Disconnect";
            this.btn_disconnect.UseVisualStyleBackColor = true;
            this.btn_disconnect.Click += new System.EventHandler(this.btn_disconnect_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(610, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Status";
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_status.ForeColor = System.Drawing.Color.Red;
            this.lbl_status.Location = new System.Drawing.Point(683, 34);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(108, 19);
            this.lbl_status.TabIndex = 4;
            this.lbl_status.Text = "Disconnected";
            // 
            // btn_check
            // 
            this.btn_check.Location = new System.Drawing.Point(343, 31);
            this.btn_check.Name = "btn_check";
            this.btn_check.Size = new System.Drawing.Size(83, 23);
            this.btn_check.TabIndex = 3;
            this.btn_check.Text = "Check Status";
            this.btn_check.UseVisualStyleBackColor = true;
            this.btn_check.Click += new System.EventHandler(this.btn_check_Click);
            // 
            // btn_newlicense
            // 
            this.btn_newlicense.Location = new System.Drawing.Point(10, 19);
            this.btn_newlicense.Name = "btn_newlicense";
            this.btn_newlicense.Size = new System.Drawing.Size(104, 23);
            this.btn_newlicense.TabIndex = 5;
            this.btn_newlicense.Text = "Add New License";
            this.btn_newlicense.UseVisualStyleBackColor = true;
            this.btn_newlicense.Click += new System.EventHandler(this.btn_newlicense_Click);
            // 
            // btn_updatelicense
            // 
            this.btn_updatelicense.Location = new System.Drawing.Point(120, 19);
            this.btn_updatelicense.Name = "btn_updatelicense";
            this.btn_updatelicense.Size = new System.Drawing.Size(91, 23);
            this.btn_updatelicense.TabIndex = 5;
            this.btn_updatelicense.Text = "Update License";
            this.btn_updatelicense.UseVisualStyleBackColor = true;
            this.btn_updatelicense.Click += new System.EventHandler(this.btn_updatelicense_Click);
            // 
            // btn_searchlicense
            // 
            this.btn_searchlicense.Location = new System.Drawing.Point(217, 19);
            this.btn_searchlicense.Name = "btn_searchlicense";
            this.btn_searchlicense.Size = new System.Drawing.Size(91, 23);
            this.btn_searchlicense.TabIndex = 5;
            this.btn_searchlicense.Text = "Search License";
            this.btn_searchlicense.UseVisualStyleBackColor = true;
            this.btn_searchlicense.Click += new System.EventHandler(this.btn_searchlicense_Click);
            // 
            // gbx
            // 
            this.gbx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbx.AutoSize = true;
            this.gbx.Controls.Add(this.btn_activateFromFile);
            this.gbx.Controls.Add(this.btn_saveToFile);
            this.gbx.Controls.Add(this.licenseGrid);
            this.gbx.Controls.Add(this.btn_validate);
            this.gbx.Controls.Add(this.btn_searchlicense);
            this.gbx.Controls.Add(this.btn_updatelicense);
            this.gbx.Controls.Add(this.btn_newlicense);
            this.gbx.Location = new System.Drawing.Point(2, 61);
            this.gbx.Name = "gbx";
            this.gbx.Size = new System.Drawing.Size(797, 189);
            this.gbx.TabIndex = 6;
            this.gbx.TabStop = false;
            this.gbx.Text = "License Details";
            this.gbx.Visible = false;
            // 
            // btn_saveToFile
            // 
            this.btn_saveToFile.Location = new System.Drawing.Point(411, 19);
            this.btn_saveToFile.Name = "btn_saveToFile";
            this.btn_saveToFile.Size = new System.Drawing.Size(75, 23);
            this.btn_saveToFile.TabIndex = 8;
            this.btn_saveToFile.Text = "Save to File";
            this.btn_saveToFile.UseVisualStyleBackColor = true;
            this.btn_saveToFile.Click += new System.EventHandler(this.btn_saveToFile_Click);
            // 
            // licenseGrid
            // 
            this.licenseGrid.AllowUserToAddRows = false;
            this.licenseGrid.AllowUserToDeleteRows = false;
            this.licenseGrid.AllowUserToOrderColumns = true;
            this.licenseGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.licenseGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.licenseGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.licenseGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.licenseGrid.Location = new System.Drawing.Point(10, 48);
            this.licenseGrid.MultiSelect = false;
            this.licenseGrid.Name = "licenseGrid";
            this.licenseGrid.ReadOnly = true;
            this.licenseGrid.Size = new System.Drawing.Size(779, 135);
            this.licenseGrid.TabIndex = 7;
            // 
            // btn_validate
            // 
            this.btn_validate.Location = new System.Drawing.Point(314, 19);
            this.btn_validate.Name = "btn_validate";
            this.btn_validate.Size = new System.Drawing.Size(91, 23);
            this.btn_validate.TabIndex = 5;
            this.btn_validate.Text = "Validate";
            this.btn_validate.UseVisualStyleBackColor = true;
            this.btn_validate.Click += new System.EventHandler(this.btn_validate_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.CheckFileExists = true;
            this.saveFileDialog.DefaultExt = "lic";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog";
            // 
            // btn_activateFromFile
            // 
            this.btn_activateFromFile.Location = new System.Drawing.Point(492, 19);
            this.btn_activateFromFile.Name = "btn_activateFromFile";
            this.btn_activateFromFile.Size = new System.Drawing.Size(153, 23);
            this.btn_activateFromFile.TabIndex = 8;
            this.btn_activateFromFile.Text = "Activate License from File";
            this.btn_activateFromFile.UseVisualStyleBackColor = true;
            this.btn_activateFromFile.Click += new System.EventHandler(this.btn_activateFromFile_Click);
            // 
            // LicenseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 262);
            this.Controls.Add(this.gbx);
            this.Controls.Add(this.lbl_status);
            this.Controls.Add(this.btn_check);
            this.Controls.Add(this.btn_disconnect);
            this.Controls.Add(this.btn_connect);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.txt_userid);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_database);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_server);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LicenseForm";
            this.Text = "License Utility";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.gbx.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.licenseGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_server;
        private System.Windows.Forms.TextBox txt_database;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_userid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox txt_password;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.Button btn_disconnect;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.Button btn_check;
        private System.Windows.Forms.Button btn_newlicense;
        private System.Windows.Forms.Button btn_updatelicense;
        private System.Windows.Forms.Button btn_searchlicense;
        private System.Windows.Forms.GroupBox gbx;
        private System.Windows.Forms.Button btn_validate;
        private System.Windows.Forms.DataGridView licenseGrid;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button btn_saveToFile;
        private System.Windows.Forms.Button btn_activateFromFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

