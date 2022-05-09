using Au.BL.Abstract;
using Au.BL.Implementation;
using AU.Common;
using AU.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuApp.Login
{
    public partial class ResetPassword : Form
    {
        protected User _user;
        int userid;
        private int idOrganization = Convert.ToInt32(ConfigurationManager.AppSettings["OrgId"]);
        protected BL_ILogin _blLogin;
        public ResetPassword(User user)
        {
            _user = user;
            _blLogin = new BL_Login();
            InitializeComponent();
        }

        private void ResetPassword_Load(object sender, EventArgs e)
        {
            userid = _user.idUser;
            User_txt.Text = _user.UserName;            
        }

        private void Reset_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(Password_txt.Text) || !string.IsNullOrEmpty(NewPassword_txt.Text) || !string.IsNullOrEmpty(ConfirmNewPassword_Txt.Text))
                {
                    if (NewPassword_txt.Text.ToUpper() == ConfirmNewPassword_Txt.Text.ToUpper())
                    {
                        var updatedUsr = new User()
                        {
                            idUser = userid,
                            Password = NewPassword_txt.Text,
                            ModifiedBy = _user.UserName,
                            ModifiedOn = DateTime.Now,
                            isFirstTime = false
                        };
                        var result = _blLogin.resetUserPassword(_user.UserName, Password_txt.Text, idOrganization, updatedUsr);
                        MessageBox.Show(result);
                        this.Hide();
                        var frm = new Frm_Login();
                        frm.Show();

                    }
                    else
                    {
                        MessageBox.Show(Constants.NewConfirmPdMismatchMessage);
                    }
                }
                else
                {
                    MessageBox.Show("Enter password in all fields.");
                }
            }
            catch (Exception ex)
            {
                LogWriter.Error(ex);
                MessageBox.Show(Constants.ErrorOccurred);
                Application.Exit();
            }
        }

        private void ResetPassword_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ResetPassword_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
