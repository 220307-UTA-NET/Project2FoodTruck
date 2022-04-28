using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTruckAPI.ClassLibrary.Models
{
    public class Truck
    {
        public int ID { get; set; }
        public DateTime Day { get; set; }
        public int MenuID { get; set; }
        public int EmpID1 { get; set; }
        public int EmpID2 { get; set; }
        public string Location { get; set; }

    }
}
