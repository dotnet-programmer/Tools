namespace EncryptionManager.Interfaces;

internal interface IEncryptionService
{
	string Encrypt(string input);
	string Decrypt(string cipherText);
}