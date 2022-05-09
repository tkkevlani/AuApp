using AU.Common;
using AU.Models;
using AuApp.Login;
using AuApp.Tenants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuApp
{
    public partial class MainPage : Form
    {
        protected static string OrgName = "";
        protected User _user;
        public MainPage(User user, string OrganizationName)
        {
            _user = user;
            OrgName = OrganizationName;
            InitializeComponent();
        }
        public MainPage()
        {
            InitializeComponent();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            if (_user._byPassSwitch)
            {
                Org_tab.Visible = true;
            }
            enableTabs(_user);
            this.Text = OrgName;
        }


        private void enableTabs(User user)
        {
            switch (user.idrole)
            {               
                case 1: //Receptionist
                    Org_tab.Visible = false;
                    StocksTab.Visible = false;
                    UsersTab.Visible = false;
                    AuditTab.Visible = false;
                    break;
                case 2: //SalesMan
                    Org_tab.Visible = false;
                    StocksTab.Visible = false;
                    UsersTab.Visible = false;
                    AuditTab.Visible = false;
                    break;
                case 3: //Owner
                    Org_tab.Visible = false;
                    break;
                case 4: //SuperAdmin
                    Org_tab.Visible = true;
                    break;           

            }
        }
        private void createToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var Prompt = new Intake(_user);
            Prompt.ShowDialog();
        }

        private void createToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var Org = new Organization_frm(_user);
            Org.ShowDialog();
        }

     
        private void UsersTab_Click(object sender, EventArgs e)
        {
            var usr = new Users_frm(_user);
            usr.ShowDialog();
            
        }

        private void MainPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void MainPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void CustomerTab_Click(object sender, EventArgs e)
        {

        }

        private void StocksTab_Click(object sender, EventArgs e)
        {
            var stk = new Stock.Stock_Frm(_user);
            stk.ShowDialog();

        }
    }
}
