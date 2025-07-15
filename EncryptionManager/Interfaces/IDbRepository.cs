using EncryptionManager.DataLayer.Dtos;

namespace EncryptionManager.Interfaces;

internal interface IDbRepository
{
	bool IsValidConnectionToDataBase();
	bool LoginToApplication(UserDto userDto);
}