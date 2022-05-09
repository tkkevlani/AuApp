namespace AuApp.Login
{
    partial class ResetPassword
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
            this.Reset_btn = new System.Windows.Forms.Button();
            this.ConfirmNewPassword_Txt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.NewPassword_txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Password_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.User_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Reset_btn);
            this.panel1.Controls.Add(this.ConfirmNewPassword_Txt);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.NewPassword_txt);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.Password_txt);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.User_txt);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(382, 175);
            this.panel1.TabIndex = 0;
            // 
            // Reset_btn
            // 
            this.Reset_btn.Location = new System.Drawing.Point(295, 143);
            this.Reset_btn.Name = "Reset_btn";
            this.Reset_btn.Size = new System.Drawing.Size(75, 23);
            this.Reset_btn.TabIndex = 27;
            this.Reset_btn.Text = "Change";
            this.Reset_btn.UseVisualStyleBackColor = true;
            this.Reset_btn.Click += new System.EventHandler(this.Reset_btn_Click);
            // 
            // ConfirmNewPassword_Txt
            // 
            this.ConfirmNewPassword_Txt.Location = new System.Drawing.Point(153, 115);
            this.ConfirmNewPassword_Txt.Name = "ConfirmNewPassword_Txt";
            this.ConfirmNewPassword_Txt.PasswordChar = '*';
            this.ConfirmNewPassword_Txt.Size = new System.Drawing.Size(217, 22);
            this.ConfirmNewPassword_Txt.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 17);
            this.label4.TabIndex = 25;
            this.label4.Text = "Confirm Password";
            // 
            // NewPassword_txt
            // 
            this.NewPassword_txt.Location = new System.Drawing.Point(153, 84);
            this.NewPassword_txt.Name = "NewPassword_txt";
            this.NewPassword_txt.PasswordChar = '*';
            this.NewPassword_txt.Size = new System.Drawing.Size(217, 22);
            this.NewPassword_txt.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 17);
            this.label3.TabIndex = 23;
            this.label3.Text = "New Password";
            // 
            // Password_txt
            // 
            this.Password_txt.Location = new System.Drawing.Point(153, 55);
            this.Password_txt.Name = "Password_txt";
            this.Password_txt.PasswordChar = '*';
            this.Password_txt.Size = new System.Drawing.Size(217, 22);
            this.Password_txt.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 17);
            this.label2.TabIndex = 21;
            this.label2.Text = "Old Password";
            // 
            // User_txt
            // 
            this.User_txt.Location = new System.Drawing.Point(153, 27);
            this.User_txt.Name = "User_txt";
            this.User_txt.ReadOnly = true;
            this.User_txt.Size = new System.Drawing.Size(217, 22);
            this.User_txt.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 19;
            this.label1.Text = "Username";
            // 
            // ResetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 175);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ResetPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Password";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ResetPassword_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ResetPassword_FormClosed);
            this.Load += new System.EventHandler(this.ResetPassword_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Reset_btn;
        private System.Windows.Forms.TextBox ConfirmNewPassword_Txt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox NewPassword_txt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Password_txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox User_txt;
        private System.Windows.Forms.Label label1;
    }
}