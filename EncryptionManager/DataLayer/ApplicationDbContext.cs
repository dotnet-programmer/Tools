using System.Reflection;
using EncryptionManager.DataLayer.Extensions;
using EncryptionManager.Interfaces;
using EncryptionManager.Models;
using EncryptionManager.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace EncryptionManager.DataLayer;

internal class ApplicationDbContext : DbContext, IApplicationDbContext
{
	public DbSet<User> Users { get; set; }

	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
	{
	}

	//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	//{
	//	optionsBuilder.UseSqlServer(new UserSettings(encryptionService).GetConnectionString());
	//	base.OnConfiguring(optionsBuilder);
	//}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		modelBuilder.SeedData();
		base.OnModelCreating(modelBuilder);
	}
}