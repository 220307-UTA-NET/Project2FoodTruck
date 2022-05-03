using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTruckAPI.ClassLibrary.Models
{
    public class TruckEmployeeListDTO
    {
        public DateTime date {get; set;}       
        public int menuID {get; set;}
        public string location { get; set;}
        public List<Employee> employees {get; set;}

    }
}
