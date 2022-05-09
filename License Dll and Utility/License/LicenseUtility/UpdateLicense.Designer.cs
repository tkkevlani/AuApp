namespace LicenseUtility
{
    partial class UpdateLicense
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
            this.validFromDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.validToDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.organizationList = new System.Windows.Forms.ComboBox();
            this.btn_UpdateLicense = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.chk_isActivated = new System.Windows.Forms.CheckBox();
            this.chk_isExpired = new System.Windows.Forms.CheckBox();
            this.chk_isTampered = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_activationKey = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txt_activationDate = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Valid From";
            // 
            // validFromDate
            // 
            this.validFromDate.Location = new System.Drawing.Point(98, 34);
            this.validFromDate.Name = "validFromDate";
            this.validFromDate.Size = new System.Drawing.Size(227, 20);
            this.validFromDate.TabIndex = 1;
            this.validFromDate.ValueChanged += new System.EventHandler(this.validFromDate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Valid To";
            // 
            // validToDate
            // 
            this.validToDate.Location = new System.Drawing.Point(98, 61);
            this.validToDate.Name = "validToDate";
            this.validToDate.Size = new System.Drawing.Size(227, 20);
            this.validToDate.TabIndex = 1;
            this.validToDate.ValueChanged += new System.EventHandler(this.validToDate_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Organization";
            // 
            // organizationList
            // 
            this.organizationList.BackColor = System.Drawing.SystemColors.Window;
            this.organizationList.Enabled = false;
            this.organizationList.FormattingEnabled = true;
            this.organizationList.Location = new System.Drawing.Point(98, 6);
            this.organizationList.Name = "organizationList";
            this.organizationList.Size = new System.Drawing.Size(227, 21);
            this.organizationList.TabIndex = 2;
            // 
            // btn_UpdateLicense
            // 
            this.btn_UpdateLicense.Location = new System.Drawing.Point(15, 177);
            this.btn_UpdateLicense.Name = "btn_UpdateLicense";
            this.btn_UpdateLicense.Size = new System.Drawing.Size(310, 23);
            this.btn_UpdateLicense.TabIndex = 3;
            this.btn_UpdateLicense.Text = "Update License";
            this.btn_UpdateLicense.UseVisualStyleBackColor = true;
            this.btn_UpdateLicense.Click += new System.EventHandler(this.btn_UpdateLicense_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Activation Date";
            // 
            // chk_isActivated
            // 
            this.chk_isActivated.AutoSize = true;
            this.chk_isActivated.Location = new System.Drawing.Point(15, 144);
            this.chk_isActivated.Name = "chk_isActivated";
            this.chk_isActivated.Size = new System.Drawing.Size(82, 17);
            this.chk_isActivated.TabIndex = 4;
            this.chk_isActivated.Text = "Is Activated";
            this.chk_isActivated.UseVisualStyleBackColor = true;
            // 
            // chk_isExpired
            // 
            this.chk_isExpired.AutoSize = true;
            this.chk_isExpired.Enabled = false;
            this.chk_isExpired.Location = new System.Drawing.Point(103, 144);
            this.chk_isExpired.Name = "chk_isExpired";
            this.chk_isExpired.Size = new System.Drawing.Size(72, 17);
            this.chk_isExpired.TabIndex = 4;
            this.chk_isExpired.Text = "Is Expired";
            this.chk_isExpired.UseVisualStyleBackColor = true;
            // 
            // chk_isTampered
            // 
            this.chk_isTampered.AutoSize = true;
            this.chk_isTampered.Enabled = false;
            this.chk_isTampered.Location = new System.Drawing.Point(181, 144);
            this.chk_isTampered.Name = "chk_isTampered";
            this.chk_isTampered.Size = new System.Drawing.Size(85, 17);
            this.chk_isTampered.TabIndex = 4;
            this.chk_isTampered.Text = "Is Tampered";
            this.chk_isTampered.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Activation Key";
            // 
            // txt_activationKey
            // 
            this.txt_activationKey.Enabled = false;
            this.txt_activationKey.Location = new System.Drawing.Point(98, 113);
            this.txt_activationKey.Name = "txt_activationKey";
            this.txt_activationKey.ReadOnly = true;
            this.txt_activationKey.Size = new System.Drawing.Size(227, 20);
            this.txt_activationKey.TabIndex = 5;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(98, 87);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(227, 20);
            this.textBox1.TabIndex = 5;
            // 
            // txt_activationDate
            // 
            this.txt_activationDate.Enabled = false;
            this.txt_activationDate.Location = new System.Drawing.Point(98, 88);
            this.txt_activationDate.Name = "txt_activationDate";
            this.txt_activationDate.ReadOnly = true;
            this.txt_activationDate.Size = new System.Drawing.Size(227, 20);
            this.txt_activationDate.TabIndex = 5;
            // 
            // UpdateLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 211);
            this.Controls.Add(this.txt_activationDate);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txt_activationKey);
            this.Controls.Add(this.chk_isTampered);
            this.Controls.Add(this.chk_isExpired);
            this.Controls.Add(this.chk_isActivated);
            this.Controls.Add(this.btn_UpdateLicense);
            this.Controls.Add(this.organizationList);
            this.Controls.Add(this.validToDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.validFromDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(359, 250);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(359, 250);
            this.Name = "UpdateLicense";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "UpdateLicense";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker validFromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker validToDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox organizationList;
        private System.Windows.Forms.Button btn_UpdateLicense;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chk_isActivated;
        private System.Windows.Forms.CheckBox chk_isExpired;
        private System.Windows.Forms.CheckBox chk_isTampered;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_activationKey;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txt_activationDate;
    }
}