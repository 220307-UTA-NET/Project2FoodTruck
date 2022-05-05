using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTruckAPI.ClassLibrary.Models
{
    public class Employee
    {
        [Required]
        public int EmployeeID { get; set; }
        [MaxLength(100)]
        public string? Name { get; set; }
        [MaxLength (100)]
        public string? PhoneNumber { get; set; }
    }
}
