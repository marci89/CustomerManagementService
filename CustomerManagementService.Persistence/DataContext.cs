using CustomerManagementService.Persistence.Configuration;
using CustomerManagementService.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagementService.Persistence
{
	/// <summary>
	/// Database context
	/// </summary>
	public class DataContext : DbContext
	{
		public DbSet<Customer> Customers { get; set; }

		public DataContext(DbContextOptions options) : base(options) { }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Set the tables with the current table's configuratuion class. This line handle all of tables where exists the table name.
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerConfiguration).Assembly);
		}
	}
}
