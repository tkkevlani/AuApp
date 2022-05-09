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

namespace AuApp
{
    public partial class Intake : Form
    {
        protected User _user;
        private int idOrganization = Convert.ToInt32(ConfigurationManager.AppSettings["OrgId"]);
        protected ICustomer_BL _customerBL;
        public Intake(User user)
        {
            fillComboBox();
            _user = user;
            _customerBL = new Customer_BL();
            InitializeComponent();
        }
        public Intake()
        {
            fillComboBox();
            _customerBL = new Customer_BL();
            InitializeComponent();
        }

        private void CFirstName_Txt_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(CFirstName_Txt.Text)) // This will prevent exception when textbox is empty   
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(CFirstName_Txt.Text, Constants.OnlyAllowString))
                {
                    MessageBox.Show("Enter Valid Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CFirstName_Txt.Text.Remove(CFirstName_Txt.Text.Length - 1);
                    CFirstName_Txt.Focus();
                }
            }
        }

        private Customer MapData()
        {
            var _cust = new Customer()
            {
                Organization = new Organization()
                {
                    idOrganization = idOrganization
                },
                Person = new Person()
                {
                    FirstName = CFirstName_Txt.Text,
                    LastName = CLastName_txt.Text,
                    DoB = CDOB_DP.Value,
                    cNIC = CcNIC_TXT.Text,
                    phone = CPhone_Txt.Text,
                    Mobile = CMobile_Txt.Text,
                    address = new Address()
                    {
                        Address1 = CAddress1_Txt.Text,
                        Address2 = CAddress2_TXT.Text,
                        City = CCity_txt.Text,
                        Province = CProvince_Cmbo.SelectedText,
                        Country = CCountry_Txt.Text,
                        PostalCode = Convert.ToInt32(CPostal_Txt.Text)
                    }
                },
                CreatedBy = _user,
                Witness1 = new Witness()
                {
                    person = new Person()
                    {
                        FirstName = W1FirstName_txt.Text,
                        LastName = W1LastName_Txt.Text,
                        DoB = W1DOB_DP.Value,
                        cNIC = W1cNIC_TXT.Text,
                        phone = W1Phone_txt.Text,
                        Mobile = W1Mobile_txt.Text,
                        address = new Address()
                        {
                            Address1 = w1Address1_txt.Text,
                            Address2 = W1Address2_txt.Text,
                            City = W1City_txt.Text,
                            Province = W1Province_cmbo.SelectedText,
                            Country = W1Country_txt.Text,
                            PostalCode = Convert.ToInt32(W1Postal_txt.Text)
                        }
                    }
                },
                Witness2 = new Witness()
                {
                    person = new Person()
                    {
                        FirstName = W2FirstName_txt.Text,
                        LastName = W2LastName_txt.Text,
                        DoB = W2Dob_dp.Value,
                        cNIC = w2cNIC_txt.Text,
                        phone = w2Phone_txt.Text,
                        Mobile = w2Mobile_txt.Text,
                        address = new Address()
                        {
                            Address1 = W2Address1_txt.Text,
                            Address2 = W2Address2_txt.Text,
                            City = w2City_txt.Text,
                            Province = W2Province_cmbo.SelectedText,
                            Country = W2Country_txt.Text,
                            PostalCode = Convert.ToInt32(W1Postal_txt.Text)
                        }
                    }
                },
                CreatedOn = DateTime.Now

            };
            return _cust;
        }

        private void Payment_btn_Click(object sender, EventArgs e)
        {
            try
            {
                var result = _customerBL.CreateCustomerBL(MapData());
                if (result >= 1)
                {
                    this.Hide();
                    var Prompt = new VehPaymentIntake(MapData());
                    Prompt.ShowDialog();

                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Constants.ErrorOccurred);
                LogWriter.Error(ex);
            }

        }

        private void fillComboBox()
        {
            try
            {

                var list = ReferenceData.LoadProvinces();
                if (list.Count > 0)
                {
                    CProvince_Cmbo.DropDownStyle = ComboBoxStyle.DropDownList;
                    CProvince_Cmbo.DataSource = list;
                    CProvince_Cmbo.ValueMember = "provinceId";
                    CProvince_Cmbo.DisplayMember = "Name";
                    CProvince_Cmbo.Text = "Select Province.";

                    W1Province_cmbo.DropDownStyle = ComboBoxStyle.DropDownList;
                    W1Province_cmbo.DataSource = list;
                    W1Province_cmbo.ValueMember = "provinceId";
                    W1Province_cmbo.DisplayMember = "Name";
                    W1Province_cmbo.Text = "Select Province.";


                    W2Province_cmbo.DropDownStyle = ComboBoxStyle.DropDownList;
                    W2Province_cmbo.DataSource = list;
                    W2Province_cmbo.ValueMember = "provinceId";
                    W2Province_cmbo.DisplayMember = "Name";
                    W2Province_cmbo.Text = "Select Province.";

                }
                else if (list.Count == 0)
                {
                    CProvince_Cmbo.DropDownStyle = ComboBoxStyle.DropDownList;
                    CProvince_Cmbo.Items.Insert(0, "There is no province in the list.");
                    CProvince_Cmbo.SelectedIndex = 0;

                    W1Province_cmbo.DropDownStyle = ComboBoxStyle.DropDownList;
                    W1Province_cmbo.Items.Insert(0, "There is no province in the list.");
                    W1Province_cmbo.SelectedIndex = 0;

                    W2Province_cmbo.DropDownStyle = ComboBoxStyle.DropDownList;
                    W2Province_cmbo.Items.Insert(0, "There is no province in the list.");
                    W2Province_cmbo.SelectedIndex = 0;

                }
            }
            catch (Exception ex)
            {
                LogWriter.Error(ex.Message, ex);
            }
        }

        private void Intake_Load(object sender, EventArgs e)
        {
            fillComboBox();
        }
    }
}
