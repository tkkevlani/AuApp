using AU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU.DL.Abstract
{
    public interface IStock_DL
    {
        int AddVehicle_DL(Vehicle _vehicle);
        List<Vehicle> LoadVehicles(string engineNumber);
        Vehicle LoadVehicle(string engineNumber);
    }
}
