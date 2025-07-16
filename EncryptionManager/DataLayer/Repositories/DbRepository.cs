using EncryptionManager.DataLayer.Dtos;
using EncryptionManager.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EncryptionManager.DataLayer.Repositories;
internal class DbRepository(IApplicationDbContext context) : IDbRepository
{
	public bool IsValidConnectionToDataBase()
	{
		try
		{
			context.Database.OpenConnection();
			context.Database.CloseConnection();
			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public bool LoginToApplication(UserDto userDto)
	{
		try
		{
			var user = context.Users.First(x => x.Name == userDto.Name);
			return user.Password == userDto.Password;
		}
		catch (Exception)
		{
			return false;
		}
	}
}