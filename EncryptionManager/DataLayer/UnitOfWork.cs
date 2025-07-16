using EncryptionManager.Interfaces;

namespace EncryptionManager.DataLayer;

internal class UnitOfWork(IApplicationDbContext context, IDbRepository dbRepository) : IUnitOfWork
{
	public IDbRepository DbRepository => dbRepository;

	public int Complete() 
		=> context.SaveChanges();

	public async Task<int> CompleteAsync()
		=> await context.SaveChangesAsync();
}