using AU.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU.Common
{
    public static class ReferenceData
    {
        public static List<Province> LoadProvinces()
        {
            List<Province> list = new List<Province>();
            list.Add(new Province { provinceId = 1, Name = "Sindh" });
            list.Add(new Province { provinceId = 2, Name = "Punjab" });
            list.Add(new Province { provinceId = 3, Name = "Balochistan" });
            list.Add(new Province { provinceId = 4, Name = "Khyber Pakhtunkhwa" });
            return list;
        }
        public static List<Condition> LoadCondition()
        {
            List<Condition> list = new List<Condition>();
            
            list.Add(new Condition { conditionId = 0, ConditionStatus = "Select condition" });
            list.Add(new Condition { conditionId = 1, ConditionStatus = "New" });
            list.Add(new Condition { conditionId = 2, ConditionStatus = "Old" });

            return list;
        }

        public static List<VehicleType> LoadVehicleTypes()
        {
            List<VehicleType> list = new List<VehicleType>();
            list.Add(new VehicleType { idVehicleType = 0, Name = "Select type" });
            list.Add(new VehicleType { idVehicleType = 1, Name = "Motorcycle" });
            list.Add(new VehicleType { idVehicleType = 2, Name = "Car" });
            return list;
        }
    }

    public class Province
    {
        public int provinceId { get; set; }
        public string Name { get; set; }
    }

    public class Condition
    {
        public int conditionId { get; set; }
        [DisplayName("Condition") ]
        public string ConditionStatus { get; set; }
    }

  
}
