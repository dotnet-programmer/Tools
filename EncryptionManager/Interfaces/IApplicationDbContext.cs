using EncryptionManager.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace EncryptionManager.Interfaces;

internal interface IApplicationDbContext : IDisposable
{
	DbSet<User> Users { get; set; }

	int SaveChanges();
}