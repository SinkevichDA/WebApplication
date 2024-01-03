using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using WebApplication7.Entities;

namespace WebApplication7.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

		public ApplicationDbContext(DbContextOptions options) : base(options)
		{
		}
		public DbSet<Dish> Dishes { get; set; }
		public DbSet<DishGroup> DishGroups { get; set; }



		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//{
		//	optionsBuilder.UseSqlServer(@"Server=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\solfi\\OneDrive\\Documents\\Students.mdf;Integrated Security = True; Connect Timeout = 30");
		//	base.OnConfiguring(optionsBuilder);
		//}

	}
}