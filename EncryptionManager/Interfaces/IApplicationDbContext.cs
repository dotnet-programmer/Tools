namespace EncryptionManager.Interfaces;

internal interface IApplicationDbContext : IDisposable
{
	int SaveChanges();
}