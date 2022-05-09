namespace LicenseUtility
{
    partial class AddLicense
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
            this.btn_AddLicense = new System.Windows.Forms.Button();
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
            this.validFromDate.Location = new System.Drawing.Point(84, 34);
            this.validFromDate.Name = "validFromDate";
            this.validFromDate.Size = new System.Drawing.Size(241, 20);
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
            this.validToDate.Location = new System.Drawing.Point(84, 61);
            this.validToDate.Name = "validToDate";
            this.validToDate.Size = new System.Drawing.Size(241, 20);
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
            this.organizationList.FormattingEnabled = true;
            this.organizationList.Location = new System.Drawing.Point(84, 6);
            this.organizationList.Name = "organizationList";
            this.organizationList.Size = new System.Drawing.Size(241, 21);
            this.organizationList.TabIndex = 2;
            // 
            // btn_AddLicense
            // 
            this.btn_AddLicense.Location = new System.Drawing.Point(15, 115);
            this.btn_AddLicense.Name = "btn_AddLicense";
            this.btn_AddLicense.Size = new System.Drawing.Size(310, 23);
            this.btn_AddLicense.TabIndex = 3;
            this.btn_AddLicense.Text = "Add License";
            this.btn_AddLicense.UseVisualStyleBackColor = true;
            this.btn_AddLicense.Click += new System.EventHandler(this.btn_AddLicense_Click);
            // 
            // AddLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 148);
            this.Controls.Add(this.btn_AddLicense);
            this.Controls.Add(this.organizationList);
            this.Controls.Add(this.validToDate);
            this.Controls.Add(this.validFromDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(359, 187);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(359, 187);
            this.Name = "AddLicense";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "AddLicense";
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
        private System.Windows.Forms.Button btn_AddLicense;
    }
}