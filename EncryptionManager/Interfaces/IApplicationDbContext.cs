using EncryptionManager.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EncryptionManager.Interfaces;

internal interface IApplicationDbContext : IDisposable
{
	DbSet<User> Users { get; set; }

	DatabaseFacade Database { get; }

	int SaveChanges();
	Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}