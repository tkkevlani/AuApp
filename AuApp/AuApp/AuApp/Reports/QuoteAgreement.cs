using AU.Models;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuApp.Reports
{
    public partial class QuoteAgreement : Form
    {
        protected Quote quote;
        public QuoteAgreement(Quote _quote)
        {
            quote = _quote;
            InitializeComponent();
        }

        private void QuoteAgreement_Load(object sender, EventArgs e)
        {
            string exeFolder = Application.StartupPath;
            string reportPath = Path.Combine(exeFolder, @"Reports\QuoteAgreement.rdlc");
            reportViewer1.LocalReport.ReportPath = reportPath;


            // Add Parameter If you need 
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Owner", quote.Owner, true));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("CustomerName", quote.CustomerName, true));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Date", quote.Date, true));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Address", quote.Address, true));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Phone", quote.Phone, true));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Mobile", quote.Mobile, true));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Brand", quote.Brand, true));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Model", quote.Model, true));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Year", quote.Year, true));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Engine", quote.Engine, true));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Chasis", quote.Chasis, true));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Condition", quote.condition, true));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Price", quote.Price, true));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Advance", quote.Advance, true));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("MonthlyInstallment", quote.MonthlyInstallments, true));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("InstallmentPeriod", quote.InstallmentPeriod, true));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Witness1", quote.Witness1, true));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Witness2", quote.Witness2, true));


            reportViewer1.RefreshReport();


        }

        private void QuoteBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
