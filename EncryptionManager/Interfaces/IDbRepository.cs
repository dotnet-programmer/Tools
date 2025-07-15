namespace EncryptionManager.Interfaces;

internal interface IDbRepository
{
	bool IsValidConnectionToDataBase();
	bool LoginToApplication();
}