using Au.BL.Abstract;
using Au.BL.Implementation;
using AU.Common;
using AU.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuApp.Tenants
{
    public partial class Organization_frm : Form
    {
        protected User _user;
        protected ITenantBL _tenant;
        public Organization_frm(User user)
        {
            _tenant = new TenantBL();
            _user = user;
            InitializeComponent();
        }


        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Save_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (_tenant.CreateOrganization(MapOrganization()))
                {
                    MessageBox.Show("Organization created successfully.");
                }
                else
                {
                    MessageBox.Show("There was an error occurred while creating organization, try again.");
                }
            }
            catch (Exception ex)
            {
                LogWriter.Error(ex);
                MessageBox.Show(Constants.ErrorOccurred);
            }
        }

        private Organization MapOrganization()
        {
            if (Name_txt.Text == string.Empty || Phone_txt.Text == string.Empty || Address_txt.Text == string.Empty || City_txt.Text == String.Empty)
            {
                MessageBox.Show("* input fields are required");
                return null;
            }
            else
            {
                var Oaddress = new Address()
                {
                    Address1 = Address_txt.Text,
                    Address2 = Address2_txt.Text,
                    City = City_txt.Text,
                    Province = Province_cmbo.SelectedText,
                    PostalCode = Convert.ToInt32(Postalcode_txt.Text),
                    Country = Country_txt.Text
                };

                var Contactaddress = new Address()
                {
                    Address1 = CAddress1_Txt.Text,
                    Address2 = CAddress2_TXT.Text,
                    City = CCity_txt.Text,
                    Province = CProvince_Cmbo.SelectedText,
                    PostalCode = Convert.ToInt32(CPostal_Txt.Text),
                    Country = CCountry_Txt.Text,
                };
                var ContactPerson = new Person()
                {
                    FirstName = CFirstName_Txt.Text,
                    LastName = CLastName_txt.Text,
                    DoB = CDOB_DP.Value,
                    cNIC = CcNIC_TXT.Text,
                    phone = CPhone_Txt.Text,
                    Mobile = CMobile_Txt.Text,
                    EmailAddress = string.Empty,
                    address = Contactaddress
                };
                var creator = new User()
                {
                    idUser = 1
                };
                var _org = new Organization();
                _org.OrganizationName = Name_txt.Text;
                _org.phone = Phone_txt.Text;
                _org.Mobile = mobile_txt.Text;
                _org.address = Oaddress;
                _org.person = ContactPerson;
                _org.CreatedBy = creator;
                _org.CreatedOn = DateTime.Now;
                return _org;
            }
        }


        private void EmptyControls()
        {
            Name_txt.Text = string.Empty;

        }

        private void Organization_frm_Load(object sender, EventArgs e)
        {
            fillComboBox();
        }

        private void fillComboBox()
        {
            try
            {

                var list = ReferenceData.LoadProvinces();
                if (list.Count > 0)
                {
                    Province_cmbo.DropDownStyle = ComboBoxStyle.DropDownList;
                    Province_cmbo.DataSource = list;
                    Province_cmbo.ValueMember = "provinceId";
                    Province_cmbo.DisplayMember = "Name";
                    Province_cmbo.Text = "Select Province.";

                    CProvince_Cmbo.DropDownStyle = ComboBoxStyle.DropDownList;
                    CProvince_Cmbo.DataSource = list;
                    CProvince_Cmbo.ValueMember = "provinceId";
                    CProvince_Cmbo.DisplayMember = "Name";
                    CProvince_Cmbo.Text = "Select Province.";

                }
                else if (list.Count == 0)
                {
                    Province_cmbo.DropDownStyle = ComboBoxStyle.DropDownList;
                    Province_cmbo.Items.Insert(0, "There is no province in the list.");
                    Province_cmbo.SelectedIndex = 0;

                    CProvince_Cmbo.DropDownStyle = ComboBoxStyle.DropDownList;
                    CProvince_Cmbo.Items.Insert(0, "There is no province in the list.");
                    CProvince_Cmbo.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                LogWriter.Error(ex.Message, ex);
            }

        }
    }
}
