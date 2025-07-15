using EncryptionManager.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace EncryptionManager.DataLayer.Extensions;

internal static class ModelBuilderExtensions
{
	public static void SeedData(this ModelBuilder modelBuilder)
	{
		SeedUsers(modelBuilder);
	}

	private static void SeedUsers(ModelBuilder modelBuilder)
		=> modelBuilder.Entity<User>().HasData(
			new User { UserId = 1, Name = "admin", Password = "admin" },
			new User { UserId = 2, Name = "user1", Password = "user1" }
			);
}