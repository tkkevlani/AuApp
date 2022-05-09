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
    public partial class Users_frm : Form
    {
        protected User usr;
        protected IUser_BL _usrbl;
        int OrgId = Convert.ToInt32(ConfigurationManager.AppSettings["OrgId"]);
        string appid = ConfigurationManager.AppSettings["AppId"].ToString();
        string TemporaryPassword = ConfigurationManager.AppSettings["TemporaryPassword"].ToString();
        public Users_frm(User _usr)
        {
            usr = _usr;
            _usrbl = new User_BL();
            InitializeComponent();
        }
        public Users_frm()
        {
            _usrbl = new User_BL();
            InitializeComponent();
        }

        private void Users_frm_Load(object sender, EventArgs e)
        {
            CreateUsr_GP.Visible = false;
            fillComboBox();
            fillGrid(_usrbl.LoadUser());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search_GP.Visible = false;
            CreateUsr_GP.Visible = true;
        }
        private void fillComboBox()
        {
            try
            {
                var list = _usrbl.getRoles();
                if (list.Count > 0)
                {
                    Role_cmbo.DropDownStyle = ComboBoxStyle.DropDownList;
                    Role_cmbo.DataSource = list;
                    Role_cmbo.ValueMember = "idRole";
                    Role_cmbo.DisplayMember = "Name";
                    Role_cmbo.Text = "Select role";

                }
                else if (list.Count == 0)
                {
                    Role_cmbo.DropDownStyle = ComboBoxStyle.DropDownList;
                    Role_cmbo.Items.Insert(0, "There is no available roles.");
                    Role_cmbo.SelectedIndex = 0;

                }
            }
            catch (Exception ex)
            {
                LogWriter.Error(ex);
            }
        }

        private void fillGrid(List<User> list)
        {
            try
            {
                Result_grd.DataSource = list;
                this.Result_grd.Columns["idUser"].Visible = false;
                this.Result_grd.Columns["Password"].Visible = false;
                this.Result_grd.Columns["idrole"].Visible = false;
                this.Result_grd.Columns["_isLogged"].Visible = false;
                this.Result_grd.Columns["LoginMessage"].Visible = false;
                this.Result_grd.Columns["_byPassSwitch"].Visible = false;

                //datagrid has calculated it's widths so we can store them
                for (int i = 0; i <= Result_grd.Columns.Count - 1; i++)
                {
                    //store autosized widths
                    int colw = Result_grd.Columns[i].Width;
                    //remove autosizing
                    Result_grd.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    Result_grd.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    //set width to calculated by autosize
                    Result_grd.Columns[i].Width = colw;
                }
            }
            catch (Exception ex)
            {
                LogWriter.Error(ex);
                MessageBox.Show(Constants.ErrorOccurred);
            }

        }

        private void Save_btn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(User_txt.Text))
            {
                int result = 0;
                try
                {
                    var user = new User();
                    user.UserName = User_txt.Text;
                    user.Password = string.IsNullOrEmpty(Password_txt.Text) ? TemporaryPassword : Password_txt.Text;
                    user.idorganization = OrgId;
                    user.isLocked = false;
                    user.FailureAttemptCount = 0;
                    user.idrole = Convert.ToInt32(Role_cmbo.SelectedValue);
                    user.CreatedOn = DateTime.Now;
                    user.CreatedBy = usr != null ? usr.UserName : appid;
                    user.isFirstTime = true;
                    if (!Userid_chk.Checked)
                    {
                        result = _usrbl.createUser(user);
                    }
                    else if (Userid_chk.Checked)
                    {
                        user.idUser = Convert.ToInt32(Userid_chk.Text);
                        user.ModifiedOn = DateTime.Now;
                        user.ModifiedBy = usr != null ? usr.UserName : appid;
                        result = _usrbl.ResetUser(user);
                    }
                    if (result >= 1)
                    {
                        MessageBox.Show(Constants.UserCreationMessage);
                    }
                    fillGrid(_usrbl.LoadUser());
                    CreateUsr_GP.Visible = false;
                    Search_GP.Visible = true;
                }
                catch (Exception ex)
                {
                    LogWriter.Error(ex);
                    MessageBox.Show(Constants.ErrorOccurred);
                }
            }
        }

        private void Search_btn_Click(object sender, EventArgs e)
        {
            textSearch(Search_txt.Text);
        }

        private void textSearch(string text)
        {
            fillGrid(_usrbl.LoadUser(text));
        }

        private void Search_txt_TextChanged(object sender, EventArgs e)
        {
            textSearch(Search_txt.Text);
        }

        private void clearControls()
        {
            User_txt.Text = string.Empty;
            Search_txt.Text = string.Empty;
        }

        private void Result_grd_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Search_GP.Visible = false;
            CreateUsr_GP.Visible = true;
            Save_btn.Text = "Reset";
            Userid_chk.Checked = true;
            Userid_chk.Text = Result_grd.CurrentRow.Cells["idUser"].Value.ToString();
            User_txt.ReadOnly = true;
            User_txt.Text = Result_grd.CurrentRow.Cells["UserName"].Value.ToString();
            Role_cmbo.Text = Result_grd.CurrentRow.Cells["Role"].Value.ToString();
        }

        private void Search_GP_Enter(object sender, EventArgs e)
        {

        }

        private void CreateUsr_GP_Enter(object sender, EventArgs e)
        {

        }

        private void Result_grd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
