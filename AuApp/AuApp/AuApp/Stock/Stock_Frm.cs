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

namespace AuApp.Stock
{
    public partial class Stock_Frm : Form
    {
        protected User usr;
        protected IStock_BL _stock;

        public Stock_Frm()
        {
            InitializeComponent();
        }
        public Stock_Frm(User _usr)
        {
            _stock = new Stock_BL();
            usr = _usr;
            InitializeComponent();

        }

        private void Stock_Frm_Load(object sender, EventArgs e)
        {
            LogWriter.Info("Stock form initiated");
            StockInfo_GP.Visible = false;
            year_Dtp.Format = DateTimePickerFormat.Custom;
            year_Dtp.CustomFormat = "yyyy";
            year_Dtp.ShowUpDown = true;
            fillGrid(string.Empty);

        }

        private void addStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fillComboBox();
            Search_GP.Visible = false;
            StockInfo_GP.Visible = true;
            

        }
        

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void fillComboBox()
        {

            try
            {

                var _conditions = ReferenceData.LoadCondition();
                if (_conditions.Count > 0)
                {
                    condition_cmbo.DropDownStyle = ComboBoxStyle.DropDownList;
                    condition_cmbo.DataSource = _conditions;
                    condition_cmbo.ValueMember = "conditionId";
                    condition_cmbo.DisplayMember = "ConditionStatus";


                }
                else if (_conditions.Count == 0)
                {
                    condition_cmbo.DropDownStyle = ComboBoxStyle.DropDownList;
                    condition_cmbo.Items.Insert(0, "It's Empty");
                    condition_cmbo.SelectedIndex = 0;

                }

                var _vehicleType = ReferenceData.LoadVehicleTypes();
                if (_vehicleType.Count > 0)
                {
                    VehicleType_Cmbo.DropDownStyle = ComboBoxStyle.DropDownList;
                    VehicleType_Cmbo.DataSource = _vehicleType;
                    VehicleType_Cmbo.ValueMember = "idVehicleType";
                    VehicleType_Cmbo.DisplayMember = "Name";
                }
                else if (_vehicleType.Count == 0)
                {
                    VehicleType_Cmbo.DropDownStyle = ComboBoxStyle.DropDownList;
                    VehicleType_Cmbo.Items.Insert(0, "It's Empty");
                    VehicleType_Cmbo.SelectedIndex = 0;

                }
            }
            catch (Exception ex)
            {
                LogWriter.Error(ex.Message, ex);
            }

        }

        private void fillGrid(string engineNumber)
        {
            try
            {
                var list = _stock.LoadVehiclesBL(engineNumber);
                
                Result_grd.DataSource = list;
                Result_grd.DataSource = list.Select(o => new
                {
                    idvehicle = o.idVehicle,
                    VehicleType_idVehicleType = o.vehicleType.idVehicleType,
                    Type = o.vehicleType.Name,
                    idBrand = o.brand.idBrand,
                    Make = o.brand.Name,
                    Model = o.Model,
                    Year = o.year,
                    Engine = o.EngineNumber,
                    Chasis = o.ChasisNumber,
                    Condition = o.isNew == true ? "New" : "Old",
                    Price = o.baseprice,
                    iduser = o.CreatedBy.idUser,
                    CreatedBy = o.CreatedBy.UserName,
                    CreatedOn = o.CreatedOn,
                    ModifiedOn = o.ModifiedOn,
                    ModifedBy = o.ModifiedBy.idUser
                }).ToList();

                this.Result_grd.Columns["idvehicle"].DisplayIndex = 0;
                this.Result_grd.Columns["VehicleType_idVehicleType"].DisplayIndex = 1;
                this.Result_grd.Columns["Type"].DisplayIndex = 2;
                this.Result_grd.Columns["idBrand"].DisplayIndex = 3;
                this.Result_grd.Columns["Make"].DisplayIndex = 4;
                this.Result_grd.Columns["Model"].DisplayIndex = 5;
                this.Result_grd.Columns["Year"].DisplayIndex = 6;
                this.Result_grd.Columns["Engine"].DisplayIndex = 7;
                this.Result_grd.Columns["Chasis"].DisplayIndex = 8;
                this.Result_grd.Columns["Condition"].DisplayIndex = 9;
                this.Result_grd.Columns["Price"].DisplayIndex = 10;
                this.Result_grd.Columns["iduser"].DisplayIndex = 11;
                this.Result_grd.Columns["CreatedBy"].DisplayIndex = 12;
                this.Result_grd.Columns["CreatedOn"].DisplayIndex = 13;
                this.Result_grd.Columns["ModifiedOn"].DisplayIndex = 14;
                this.Result_grd.Columns["ModifedBy"].DisplayIndex = 15;

                this.Result_grd.Columns["idVehicle"].Visible = false;
                this.Result_grd.Columns["VehicleType_idVehicleType"].Visible = false;
                this.Result_grd.Columns["idBrand"].Visible = false;
                this.Result_grd.Columns["iduser"].Visible = false;
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
            savevehicle();
        }

        private void savevehicle()
        {
            try
            {
                if (checkControlInputs())
                {
                    var vehicle = new Vehicle()
                    {
                        brand = new Brand() { Name = Brand_txt.Text },
                        vehicleType = new VehicleType { Name = VehicleType_Cmbo.Text },
                        isNew = Convert.ToInt32(condition_cmbo.SelectedValue) == 1 ? true : false,
                        EngineNumber = Engine_txt.Text,
                        ChasisNumber = Chasis_txt.Text,
                        Model = Model_txt.Text,
                        year = year_Dtp.Value.Year,
                        CreatedOn = DateTime.Now,
                        CreatedBy = new User() { idUser = usr.idUser },
                        baseprice = Convert.ToDouble(Price_txt.Text)
                    };
                    var result = _stock.AddVehicle(vehicle);
                    if (result >= 1)
                    {
                        Search_GP.Visible = true;
                        StockInfo_GP.Visible = false;
                        CleanControls();
                        fillGrid(string.Empty);
                        MessageBox.Show(String.Format("{0} added successfully", VehicleType_Cmbo.SelectedText));

                    }
                    else
                    {
                        MessageBox.Show(String.Format("An error occurred while adding {0}.", VehicleType_Cmbo.SelectedText));
                    }
                }
                else
                {
                    MessageBox.Show("Please enter all values");
                }
            }
            catch (Exception ex)
            {
                LogWriter.Error(ex);
                MessageBox.Show(Constants.ErrorOccurred);
            }
        }

        private bool checkControlInputs()
        {
            if (!string.IsNullOrEmpty(Brand_txt.Text)
                  && (Convert.ToInt32(VehicleType_Cmbo.SelectedValue) != 0)
                  && Convert.ToInt32(condition_cmbo.SelectedValue) != 0
                  && !string.IsNullOrEmpty(Engine_txt.Text)
                  && !string.IsNullOrEmpty(Chasis_txt.Text)
                  && !string.IsNullOrEmpty(Model_txt.Text)
                  && year_Dtp.Value.Year >= 0
                  && !string.IsNullOrEmpty(Price_txt.Text)
                  )
                return true;
            else
                return false;
        }
        private void CleanControls()
        {

            Brand_txt.Text = string.Empty;
            Engine_txt.Text = string.Empty;
            Chasis_txt.Text = string.Empty;
            Model_txt.Text = string.Empty;
            year_Dtp.Value = DateTime.Now;
            Price_txt.Text = string.Empty;
            condition_cmbo.SelectedIndex = 0;
            VehicleType_Cmbo.SelectedIndex = 0;
        }

        private void year_Dtp_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
