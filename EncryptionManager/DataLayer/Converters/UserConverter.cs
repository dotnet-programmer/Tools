using EncryptionManager.DataLayer.Dtos;
using EncryptionManager.Models.Domain;

namespace EncryptionManager.DataLayer.Converters;

internal static class UserConverter
{
	public static UserDto ToDto(this User user)
		=> new()
		{
			Name = user.Name,
			Password = user.Password,
		};

	public static User ToDao(this UserDto userDto)
		=> new()
		{
			Name = userDto.Name,
			Password = userDto.Password,
		};
}