using License.Model;
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
    public partial class UpdateLicense : Form
    {
        public LicenseInfo license;
        public UpdateLicense(LicenseInfo licenseInfo)
        {
            InitializeComponent();

            InitilizeData(licenseInfo);
        }

        private void InitilizeData(LicenseInfo licenseInfo)
        {
            license = licenseInfo;

            var listValue = new { Text = licenseInfo.OrganizationName, Value = licenseInfo.OrganizationId };
            organizationList.Items.Add(listValue);
            organizationList.SelectedItem = listValue;
            organizationList.DisplayMember = "Text";
            organizationList.ValueMember = "Value";

            validFromDate.Value = licenseInfo.ValidFrom;
            validToDate.Value = licenseInfo.ValidTo;
            if (licenseInfo.ActivationDate != null)
                txt_activationDate.Text = licenseInfo.ActivationDate.GetValueOrDefault().ToShortDateString();
            txt_activationKey.Text = licenseInfo.ActivationKey;
            chk_isActivated.Checked = licenseInfo.IsActivated;
            chk_isExpired.Checked = licenseInfo.IsExpired;
            chk_isTampered.Checked = licenseInfo.IsTampered;
        }

        private void btn_UpdateLicense_Click(object sender, EventArgs e)
        {
            if (organizationList.SelectedItem == null)
            {
                MessageBox.Show("Please select organization.");
                return;
            }

            var orgid = (organizationList.SelectedItem as dynamic).Value;
            var fromDate = validFromDate.Value.Date;
            var toDate = validToDate.Value.Date;
            var isActivated = chk_isActivated.Checked;

            if (toDate.Date < DateTime.Now.Date)
                chk_isExpired.Checked = true;

            license.ValidFrom = fromDate;
            license.ValidTo = toDate;
            license.IsExpired = chk_isExpired.Checked;
            license.IsActivated = isActivated;

            Operations.UpdateLicense(license);

            this.Dispose();
        }

        private void ValidateDate()
        {
            var fromDate = validFromDate.Value.Date;
            var toDate = validToDate.Value.Date;

            if (toDate.Date < fromDate.Date)
                MessageBox.Show("ValiedTo date must be greater than ValidFrom date.");
        }

        private void validToDate_ValueChanged(object sender, EventArgs e)
        {
            ValidateDate();
        }

        private void validFromDate_ValueChanged(object sender, EventArgs e)
        {
            ValidateDate();
        }
    }
}
