using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTruckAPI.ClassLibrary.Models
{
    public class EmployeeTruckLink
    {
        public int EmployeeTruckLinkID { get; set; }
        public int EmployeeID { get; set; }
        public int TruckID { get; set; }
    }
}
