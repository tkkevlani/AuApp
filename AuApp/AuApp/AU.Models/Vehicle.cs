
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU.Models
{
    public class Vehicle
    {
        public int idVehicle { get; set; }
        public VehicleType vehicleType { get; set; }
        public Brand brand { get; set; }
        public string Model { get; set; }
        public int year { get; set; }

        [DisplayName("Condition")]
        public bool isNew { get; set; }
        [DisplayName("Engine Number")]
        public string EngineNumber { get; set; }
        [DisplayName("Chasis Number")]
        public string ChasisNumber { get; set; }
        [DisplayName("Base Price")]

        public double baseprice { get; set; }
        [DisplayName("Created By")]
        public User CreatedBy { get; set; }
        [DisplayName("Created On")]
        public DateTime CreatedOn { get; set; }
        [DisplayName("Modified by")]
        public User ModifiedBy { get; set; }
        [DisplayName("Modified On")]
        public DateTime ModifiedOn { get; set; }


    }
}
