using Au.BL.Abstract;
using Au.BL.Implementation;
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
    public partial class VehPaymentIntake : Form
    {
        protected User _loggedUser;
        protected Customer _customer;
        protected IStock_BL _stock;

        public VehPaymentIntake(Customer Customer, User loggedUser)
        {
            _loggedUser = loggedUser;
            _customer = Customer;
            _stock = new Stock_BL();
            InitializeComponent();
        }

        public VehPaymentIntake(Customer Customer)
        {
            _customer = Customer;
            _stock = new Stock_BL();
            InitializeComponent();
        }

        private void Agent_chk_CheckedChanged(object sender, EventArgs e)
        {
            if (Agent_chk.Checked)
            {
                Commission_txt.Enabled = true;
                Commission_txt.Focus();
            }
            else
            {
                Commission_txt.Enabled = false;
                Commission_txt.Clear();
            }
        }

        private void FixedPayment_rb_CheckedChanged(object sender, EventArgs e)
        {
            if (FixedPayment_rb.Checked)
            {
                FixedInstallment_txt.Enabled = false;
                FixedInstallment_txt.Clear();

                FixedPayment_txt.Enabled = true;
                FixedPayment_txt.Focus();
            }
        }

        private void FixedInstallment_rb_CheckedChanged(object sender, EventArgs e)
        {
            if (FixedInstallment_rb.Checked)
            {
                FixedPayment_txt.Enabled = false;
                FixedPayment_txt.Clear();

                FixedInstallment_txt.Enabled = true;
                FixedInstallment_txt.Focus();
            }
        }

        private void VehPaymentIntake_Load(object sender, EventArgs e)
        {
            Date_lbl.Text = DateTime.Now.Date.ToShortDateString();
            FullName_lbl.Text = string.Concat(_customer.Person.FirstName, " ", _customer.Person.LastName);
            Address_Lbl.Text = string.Concat(_customer.Person.address.Address1, " ", _customer.Person.address.Address2, " ", _customer.Person.address.City, " ", _customer.Person.address.Province);
            Phone_lbl.Text = _customer.Person.phone;
            Mobile_lbl.Text = _customer.Person.Mobile;

        }

        private void SelectVehicle(string engine)
        {
            var result = _stock.SelectVehicleBL(engine);
            if (result != null)
            {
                Brand_txt.Text = result.brand.Name;
                Model_txt.Text = result.Model;
                Year_txt.Text = result.year.ToString();
                Engine_txt.Text = result.EngineNumber;
                Chasis_txt.Text = result.ChasisNumber;
                Condition_txt.Text = result.isNew == true ? "New" : "Old";
                BasePrice_txt.Text = result.baseprice.ToString();
                SellingPrice_Txt.Focus();
            }
            else
            {
                MessageBox.Show(string.Format("Stock is not avaiable for this Engine number: {0}", engine));
            }
        }

        private void Search_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SelectVehicle(Search_txt.Text);
            }
        }

        private void Search_btn_Click(object sender, EventArgs e)
        {
            SelectVehicle(Search_txt.Text);
        }

        private void Cal_btn_Click(object sender, EventArgs e)
        {
            var SellingPrice = Convert.ToInt32(SellingPrice_Txt.Text);
            var Commission = string.IsNullOrEmpty(Commission_txt.Text) ? 0 : Convert.ToInt32(Commission_txt.Text);
            var FixedPayment = string.IsNullOrEmpty(FixedPayment_txt.Text) ? 0 : Convert.ToInt32(FixedPayment_txt.Text);
            var FixedInstallment = string.IsNullOrEmpty(FixedInstallment_txt.Text) ? 0 : Convert.ToInt32(FixedInstallment_txt.Text);
            var AdvancePayment = string.IsNullOrEmpty(Advance_txt.Text) ? 0 : Convert.ToInt32(Advance_txt.Text);
            var finalPrice = SellingPrice + Commission;

            if (FixedPayment_rb.Checked)
            {
                MInstallment_lbl.Text = FixedPayment.ToString();
                Months_lbl.Text = calculteInstallmentPeriod(FixedPayment, finalPrice, AdvancePayment).ToString();
            }
            else if (FixedInstallment_rb.Checked)
            {
                MInstallment_lbl.Text = calculteInstallmentAmount(FixedInstallment, finalPrice, AdvancePayment).ToString();
                Months_lbl.Text = FixedInstallment.ToString();
            }

            FinalPrice_lbl.Text = finalPrice.ToString();
            Advance_lbl.Text = AdvancePayment.ToString();

        }

        private int calculteInstallmentPeriod(double fixedPayment, double finalPrice, double advancePayment)
        {
            return Convert.ToInt32(Math.Ceiling((finalPrice - advancePayment) / fixedPayment));
        }

        private double calculteInstallmentAmount(int months, double finalPrice, double advancePayment)
        {
            return Convert.ToDouble(Math.Ceiling((finalPrice - advancePayment) / months));
        }

        private void Print_btn_Click(object sender, EventArgs e)
        {
            var list = new List<Quote>();
            var quote = new Quote()
            {
                Owner = ConfigurationManager.AppSettings["OrgName"].ToString(),
                Date = DateTime.Now.ToShortDateString(),
                CustomerName = FullName_lbl.Text,
                Address = Address_Lbl.Text,
                Phone = Phone_lbl.Text,
                Mobile = Mobile_lbl.Text,
                Brand = Brand_txt.Text,
                Model = Model_txt.Text,
                Year = Year_txt.Text,
                Engine = Engine_txt.Text,
                Chasis = Chasis_txt.Text,
                condition = Condition_txt.Text,
                Price = FinalPrice_lbl.Text,
                Advance = Advance_lbl.Text,
                MonthlyInstallments = MInstallment_lbl.Text,
                InstallmentPeriod = Months_lbl.Text,
                Witness1 = string.Empty,//string.Concat(_customer.Witness1.person.FirstName, " ", _customer.Witness1.person.LastName),
               
                Witness2 =string.Empty  //string.Concat(_customer.Witness2.person.FirstName, " ", _customer.Witness2.person.LastName)
            };
            //list.Add(quote);
            var dialog = new Reports.QuoteAgreement(quote);
            dialog.ShowDialog();
        }
    }
}
