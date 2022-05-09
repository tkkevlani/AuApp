using License.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LicenseUtility
{
    public partial class LicenseForm : Form
    {
        public LicenseForm()
        {
            InitializeComponent();
        }

        private void btn_check_Click(object sender, EventArgs e)
        {
            if (Operations.CheckConnection())
            {
                lbl_status.Text = "Connected";
                lbl_status.ForeColor = Color.Green;
                gbx.Visible = true;
            }
            else
            {
                lbl_status.Text = "Disconnected";
                lbl_status.ForeColor = Color.Red;
                gbx.Visible = false;
            }
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            Operations.Connect(txt_server.Text, txt_database.Text, txt_userid.Text, txt_password.Text);
            btn_check_Click(sender, e);
            btn_searchlicense_Click(sender, e);
        }

        private void btn_disconnect_Click(object sender, EventArgs e)
        {
            Operations.Disconnect();
            btn_check_Click(sender, e);
        }

        private void btn_newlicense_Click(object sender, EventArgs e)
        {
            var addlicenseForm = new AddLicense();
            addlicenseForm.ShowDialog();
        }

        private void btn_searchlicense_Click(object sender, EventArgs e)
        {
            var licenses = Operations.GetLicenses(null, null);
            if (licenses != null && licenses.Count > 0)
                licenseGrid.DataSource = licenses;
            else
                MessageBox.Show("No License Data found");

        }

        private void btn_updatelicense_Click(object sender, EventArgs e)
        {
            if (licenseGrid.SelectedRows.Count > 0)
            {
                bool isActivated = Convert.ToBoolean(licenseGrid.SelectedRows[0].Cells["IsActivated"].Value);
                if (isActivated == false)
                {
                    int idLicense = Convert.ToInt32(licenseGrid.SelectedRows[0].Cells["idLicense"].Value.ToString());
                    var licenses = Operations.GetLicenses(null, idLicense);

                    if (licenses != null && licenses.Count > 0)
                    {
                        var updatelicenseForm = new UpdateLicense(licenses.First());
                        updatelicenseForm.ShowDialog();
                    }
                }
                else
                    MessageBox.Show("Activated License cannot be modified");
            }
            else
                MessageBox.Show("No License selected, please select license row to update");
        }

        private void btn_validate_Click(object sender, EventArgs e)
        {
            if (licenseGrid.SelectedRows.Count > 0)
            {
                int idLicense = Convert.ToInt32(licenseGrid.SelectedRows[0].Cells["idLicense"].Value.ToString());
                var licenses = Operations.GetLicenses(null, idLicense);

                if (licenses != null && licenses.Count > 0)
                {
                    var validateMessage = Operations.ValidateLicense(licenses.First().OrganizationId, idLicense);
                    MessageBox.Show(validateMessage);
                }
            }
            else
                MessageBox.Show("No License selected, please select license row to validate");
        }

        private void btn_saveToFile_Click(object sender, EventArgs e)
        {
            if (licenseGrid.SelectedRows.Count > 0)
            {
                int idLicense = Convert.ToInt32(licenseGrid.SelectedRows[0].Cells["idLicense"].Value.ToString());
                var licenses = Operations.GetLicenses(null, idLicense);

                if (licenses != null && licenses.Count > 0)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.InitialDirectory = @"C:\";
                    saveFileDialog1.Title = "Save License File";
                    saveFileDialog1.CheckFileExists = false;
                    saveFileDialog1.CheckPathExists = true;
                    saveFileDialog1.DefaultExt = ".lic";
                    saveFileDialog1.Filter = "Text files (*.lic)|*.lic|All files (*.*)|*.*";
                    saveFileDialog1.FilterIndex = 2;
                    saveFileDialog1.RestoreDirectory = true;
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        var fullPath = saveFileDialog1.FileName;

                        Operations.SaveFile(fullPath, licenses.First());
                    }
                }
            }
            else
                MessageBox.Show("No License selected, please select license row to save");
        }

        private void btn_activateFromFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog saveFileDialog1 = new OpenFileDialog();
            saveFileDialog1.InitialDirectory = @"C:\";
            saveFileDialog1.Title = "Browse License File";
            saveFileDialog1.CheckFileExists = true;
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.DefaultExt = ".lic";
            saveFileDialog1.Filter = "Text files (*.lic)|*.lic";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            saveFileDialog1.ReadOnlyChecked = true;
            saveFileDialog1.ShowReadOnly = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var fullPath = saveFileDialog1.FileName;

                Operations.ActivateLicenseFromFile(fullPath);
            }
        }
    }
}
