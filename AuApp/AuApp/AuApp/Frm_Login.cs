using Au.BL.Abstract;
using Au.BL.Implementation;
using AU.Common;
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

namespace AuApp
{
    public partial class Frm_Login : Form
    {

        private int idOrganization = Convert.ToInt32(ConfigurationManager.AppSettings["OrgId"]);
        private static string orgname = ConfigurationManager.AppSettings["OrgName"].ToString();
        protected BL_ILogin _blLogin;
        public Frm_Login()
        {
            
            _blLogin = new BL_Login();
            InitializeComponent();
        }

        private void Frm_Login_Load(object sender, EventArgs e)
        {
            lbl_OrganizationName.Text = orgname;
            Testconnectivity();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            _Login(Txt_Username.Text, Txt_Password.Text);
        }
        private void Testconnectivity()
        {
            _blLogin = new BL_Login();
            if (!(_blLogin.checkdatabaseConnectivity()))
                MessageBox.Show("Database connection failed, checked error logs.");
        }
        private void Frm_Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Frm_Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void _Login(string _username, string _password)
        {
            try
            {
                LogWriter.Info("Login intiated");
                if (!string.IsNullOrEmpty(_username) && !string.IsNullOrEmpty(_password))
                {
                    var _mappeduser = _blLogin.validatelogin(_username, _password, idOrganization);
                    if (!_mappeduser._isLogged)
                    {
                        var _dialoge = MessageBox.Show(Constants.IncorrectLogin, "Warning", MessageBoxButtons.OK);
                        if (_dialoge == DialogResult.OK)
                        {
                            Txt_Password.Text = string.Empty;
                            Txt_Password.Focus();
                        }
                    }
                    else if (_mappeduser._isLogged)
                    {
                        if (_mappeduser.isFirstTime)
                        {
                            var _dialogeResult = MessageBox.Show(Constants.LoginForceChangePdMessage, "Reset Password", MessageBoxButtons.OKCancel);
                            if (_dialogeResult == DialogResult.OK)
                            {
                                var Resetfrm = new Login.ResetPassword(_mappeduser);
                                this.Hide();
                                Resetfrm.Show();
                            }
                            else
                            {
                                Application.Exit();
                            }
                        }
                        else
                        {
                            var mainform = new MainPage(_mappeduser, orgname);
                            this.Hide();
                            mainform.Show();

                        }
                    }
                    else
                    {
                        MessageBox.Show(Constants.InputFieldMissingMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                LogWriter.Error(ex);
            }
        }

        private void Txt_Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                _Login(Txt_Username.Text, Txt_Password.Text);
            }
        }
    }
}
