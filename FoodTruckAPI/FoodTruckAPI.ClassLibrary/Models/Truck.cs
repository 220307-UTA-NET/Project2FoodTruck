using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTruckAPI.ClassLibrary.Models
{
    public class Truck
    {
        public int TruckID { get; set; }
        public DateTime Day { get; set; }
        public int MenuID { get; set; }
        public List<EmployeeTruckLink> workingEmployees { get; set; }
        public string Location { get; set; }

    }
}
