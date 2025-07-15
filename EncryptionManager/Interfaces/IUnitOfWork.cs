namespace EncryptionManager.Interfaces;

internal interface IUnitOfWork
{
	IDbRepository DbRepository { get; }
	void Complete();
}