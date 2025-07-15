using EncryptionManager.Interfaces;

namespace EncryptionManager.DataLayer;

internal class UnitOfWork(IApplicationDbContext context, IDbRepository dbRepository) : IUnitOfWork
{
	public IDbRepository DbRepository => dbRepository;

	public void Complete() 
		=> context.SaveChanges();
}