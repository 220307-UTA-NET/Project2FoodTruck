using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTruckDataAccessLibrary.Models
{
    public class Truck
    {
        public int ID { get; set; }
        public DateTime Day { get; set; }
        public int MenuID { get; set; }
        public string Employee1 { get; set; }
        public string Employee2 { get; set; }
        public string Location { get; set; }

    }
}
