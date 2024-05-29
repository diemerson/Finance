using Finance.Api.Data.Mappings;
using Finance.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Finance.Api.Data.AppDbContext;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
	public DbSet<Category> Categories { get; set; } = null!;
	public DbSet<Transaction> Transactions { get; set; } = null!;

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.ApplyConfiguration(new CategoryMapping());
		modelBuilder.ApplyConfiguration(new TransactionMapping());
	}
}
