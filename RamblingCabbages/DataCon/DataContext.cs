using Microsoft.EntityFrameworkCore;

namespace RamblingCabbages.DataCon
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Truck> Trucks { get; set; }
    }
}
