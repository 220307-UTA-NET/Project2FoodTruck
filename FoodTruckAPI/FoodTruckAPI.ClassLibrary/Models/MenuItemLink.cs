using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTruckAPI.ClassLibrary.Models
{
    public class MenuItemLink
    {
        public int MenuItemLinkID { get; set; }       
        public int MenuID { get; set; }    
        public int MenuItemID { get; set; }
    }
}
