using System.Reflection;
using EncryptionManager.DataLayer.Extensions;
using EncryptionManager.Interfaces;
using EncryptionManager.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace EncryptionManager.DataLayer;

internal class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options), IApplicationDbContext
{
	public DbSet<User> Users { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		modelBuilder.SeedData();
		base.OnModelCreating(modelBuilder);
	}
}