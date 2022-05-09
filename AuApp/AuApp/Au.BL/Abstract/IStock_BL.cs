using AU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Au.BL.Abstract
{
    public interface IStock_BL
    {
        int AddVehicle(Vehicle _vehicle);
        List<Vehicle> LoadVehiclesBL(string EngineNumber);
        Vehicle SelectVehicleBL(string EngineNumber);
    }
}
