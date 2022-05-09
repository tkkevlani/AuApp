using AU.DL.Abstract;
using AU.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU.DL.Implementation
{
    public class Stock_DL : IStock_DL
    {
        protected DBHelper _dbhelper;
        public Stock_DL()
        {
            _dbhelper = new DBHelper();
        }
        DataTable dtList = null;

        public int AddVehicle_DL(Vehicle _vehicle)
        {
            Dictionary<string, object> procParams = new Dictionary<string, object>();
            procParams.Add("@brandname", _vehicle.brand.Name);
            procParams.Add("@vehicleType", _vehicle.vehicleType.Name);
            procParams.Add("@Isnew", _vehicle.isNew);
            procParams.Add("@EngineNumber", _vehicle.EngineNumber);
            procParams.Add("@ChasisNumber", _vehicle.ChasisNumber);
            procParams.Add("@CreatedDate", _vehicle.CreatedOn);
            procParams.Add("@CreatedBy", _vehicle.CreatedBy.idUser);
            procParams.Add("@Model", _vehicle.Model);
            procParams.Add("@Year", _vehicle.year);
            procParams.Add("@BasePrice", _vehicle.baseprice);
            var result = _dbhelper.InsertTableData("SP_Vehicle", procParams);
            return result;
        }

        public List<Vehicle> LoadVehicles(string engineNumber)
        {
            return VehicleList(engineNumber);

        }

        private List<Vehicle> VehicleList(string engineNumber)
        {
            Dictionary<string, object> procParams = new Dictionary<string, object>();
            procParams.Add("@engineNumber", engineNumber);
            dtList = _dbhelper.GetTableData("SP_LoadStock", procParams);
            return MapVehicles(dtList);
        }

        public Vehicle LoadVehicle(string engineNumber)
        {
            Dictionary<string, object> procParams = new Dictionary<string, object>();
            procParams.Add("@EngineNumber", engineNumber);
            dtList = _dbhelper.GetTableData("SP_SelectVehicle", procParams);
            Vehicle _vehicle = null;
            if (dtList.Rows.Count > 0)
            {
                foreach (DataRow dr in dtList.Rows)
                {
                    _vehicle = new Vehicle()
                    {
                        idVehicle = Convert.ToInt32(dr["idVehicle"]),
                        vehicleType = new VehicleType()
                        {
                                                     Name = Convert.ToString(dr["VehicleType"])
                        },
                        brand = new Brand()
                        {
                           
                            Name = Convert.ToString(dr["BrandName"])
                        },
                        Model = Convert.ToString(dr["Model"]),
                        year = Convert.ToInt32(dr["Year"]),
                        EngineNumber = Convert.ToString(dr["EngineNumber"]),
                        ChasisNumber = Convert.ToString(dr["ChassisNumber"]),
                        isNew = Convert.ToBoolean(dr["IsNew"]),
                        baseprice = Convert.ToInt32(dr["BasePrice"])

                    };
                   
                }
            }
            else _vehicle = null;
            return _vehicle;
        }

        private List<Vehicle> MapVehicles(DataTable dt)
        {
            List<Vehicle> _vehicles = new List<Vehicle>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    var _vehicle = new Vehicle()
                    {
                       idVehicle = Convert.ToInt32(dr["idVehicle"]),
                        vehicleType = new VehicleType()
                        {
                            idVehicleType = Convert.ToInt32(dr["VehicleType_idVehicleType"]),
                            Name = Convert.ToString(dr["VehicleType"])
                        },
                        brand = new Brand()
                        {
                            idBrand = Convert.ToInt32(dr["Brand_idBrand"]),
                            Name = Convert.ToString(dr["BrandName"])
                        },
                        Model = Convert.ToString(dr["Model"]),
                        year = Convert.ToInt32(dr["Year"]),
                        EngineNumber = Convert.ToString(dr["EngineNumber"]),
                        ChasisNumber = Convert.ToString(dr["ChassisNumber"]),
                        isNew = Convert.ToBoolean(dr["IsNew"]),
                        baseprice = Convert.ToInt32(dr["BasePrice"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedDate"]),
                        CreatedBy = new User() { idUser = Convert.ToInt32(dr["idUser"]), UserName = Convert.ToString(dr["CreatedBy"]) },
                        ModifiedOn = dr["ModifiedOn"] != DBNull.Value ? Convert.ToDateTime(dr["ModifiedOn"]) : Convert.ToDateTime("1/1/0001"),
                        ModifiedBy = new User()
                        {
                            idUser = dr["ModifiedBy"] != DBNull.Value ? Convert.ToInt32(dr["ModifiedBy"]) : 0
                        }

                    };
                    _vehicles.Add(_vehicle);
                }
            }
            else _vehicles = null;
            return _vehicles;
        }
    }
}
