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
    public partial class AddLicense : Form
    {
        public AddLicense()
        {
            InitializeComponent();

            InitilizeData();
        }

        public void InitilizeData()
        {
            // set ValidTo date
            var fromDate = validFromDate.Value.Date;
            validToDate.Value = fromDate.AddMonths(1);


            var organizations = Operations.GetOrganizations();

            if (organizations != null && organizations.Count > 0)
            {
                foreach (var org in organizations)
                {
                    organizationList.Items.Add(new { Text = org.Value, Value = org.Key });
                }
            }

            organizationList.DisplayMember = "Text";
            organizationList.ValueMember = "Value";
            //organizationList.SelectedIndex = 0;
        }

        private void btn_AddLicense_Click(object sender, EventArgs e)
        {
            if (organizationList.SelectedItem == null)
            {
                MessageBox.Show("Please select organization.");
                return;
            }

            var orgid = (organizationList.SelectedItem as dynamic).Value;
            var fromDate = validFromDate.Value.Date;
            var toDate = validToDate.Value.Date;

            Operations.AddLicense(orgid, fromDate, toDate);

            this.Dispose();
        }

        private void ValidateDate()
        {
            var fromDate = validFromDate.Value.Date;
            var toDate = validToDate.Value.Date;

            if (toDate.Date < fromDate.Date)
                MessageBox.Show("ValiedTo date must be greater than ValidFrom date.");
        }

        private void validFromDate_ValueChanged(object sender, EventArgs e)
        {
            ValidateDate();
        }

        private void validToDate_ValueChanged(object sender, EventArgs e)
        {
            ValidateDate();
        }
    }
}
