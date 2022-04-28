using FoodTruckDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTruckDataAccessLibrary.DataAccess
{
    public class FoodTruckContext : DbContext
    {
        public FoodTruckContext(DbContextOptions<FoodTruckContext> options) : base(options) { }

        //this where we set-up our tables for SQL
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Truck> Trucks { get; set; }


    }
}
