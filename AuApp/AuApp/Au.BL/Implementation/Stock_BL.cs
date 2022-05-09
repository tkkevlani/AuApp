using Au.BL.Abstract;
using AU.DL.Abstract;
using AU.DL.Implementation;
using AU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Au.BL.Implementation
{
    public class Stock_BL : IStock_BL
    {
        protected IStock_DL _Stockdl;
        public Stock_BL()
        {
            _Stockdl = new Stock_DL();
        }

        public int AddVehicle(Vehicle _vehicle) {
            return _Stockdl.AddVehicle_DL(_vehicle);
        }
        public List<Vehicle> LoadVehiclesBL(string EngineNumber)
        {
            return _Stockdl.LoadVehicles(EngineNumber);
        }

        public Vehicle SelectVehicleBL(string EngineNumber)
        {
            return _Stockdl.LoadVehicle(EngineNumber);
        }
    }
}
