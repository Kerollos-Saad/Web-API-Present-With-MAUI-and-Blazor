
using Demo.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.Api.Data
{
	public class DemoDbContext : DbContext
	{
		public DemoDbContext(DbContextOptions options) : base(options)
		{
			
		}

		public DbSet<Product> Products { get; set; } 
	}
}
