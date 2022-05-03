using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTruckAPI.ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodTruckAPI.ClassLibrary.DataAccess
{
    public class FoodTruckContext : DbContext
    {
        public FoodTruckContext(DbContextOptions options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<MenuItemLink> MenuItemLinks { get; set; }
        public DbSet<EmployeeTruckLink> EmployeeTruckLinks { get; set; }


    }
}
