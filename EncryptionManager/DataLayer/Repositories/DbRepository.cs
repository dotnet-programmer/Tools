using EncryptionManager.Interfaces;

namespace EncryptionManager.DataLayer.Repositories;
internal class DbRepository(IApplicationDbContext context) : IDbRepository
{
	public bool IsValidConnectionToDataBase()
	{
		try
		{
			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public bool LoginToApplication()
	{
		try
		{
			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}
}