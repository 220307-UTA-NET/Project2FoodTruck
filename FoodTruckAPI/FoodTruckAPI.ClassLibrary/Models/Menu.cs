using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTruckAPI.ClassLibrary.Models
{
    public class Menu
    {
        public int ID { get; set; }
        public MenuItem Main1 { get; set; }
        public MenuItem Main2 { get; set; }
        public MenuItem Main3 { get; set; }
        public  MenuItem Drink1 { get; set; }
        public  MenuItem Drink2 { get; set; }
        public MenuItem Side1 { get; set; }
        public MenuItem Side2 { get; set; }

    }
}
