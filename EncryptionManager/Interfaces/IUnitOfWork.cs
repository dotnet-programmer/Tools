namespace EncryptionManager.Interfaces;

internal interface IUnitOfWork
{
	IDbRepository DbRepository { get; }

	int Complete();
	Task<int> CompleteAsync();
}