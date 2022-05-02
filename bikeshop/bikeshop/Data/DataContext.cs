using System;
using bikeshop.Models;
using Microsoft.EntityFrameworkCore;

namespace bikeshop.Data
{
	public class DataContext : DbContext
	{

		public DataContext(DbContextOptions<DataContext> options) : base(options) { }

		public DbSet<Employee> Employees { get; set; }

		public DbSet<Menu> Menus { get; set; }

		public DbSet<MenuItem> MenuItems { get; set; }

		public DbSet<Truck> Trucks { get; set; }

		public DbSet<MenuItemLink> MenuItemLinks { get; set; }

		protected override void OnModelCreating(ModelBuilder modelbuilder)
		{

			foreach (var relationship in modelbuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
			{
				relationship.DeleteBehavior = DeleteBehavior.Restrict;
			}

			base.OnModelCreating(modelbuilder);
		}

	}
}

