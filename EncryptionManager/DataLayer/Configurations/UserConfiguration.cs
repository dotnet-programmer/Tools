using EncryptionManager.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EncryptionManager.DataLayer.Configurations;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder
			.HasIndex(x => x.Name)
			.IsUnique();

		builder
			.Property(x => x.Name)
			.HasMaxLength(50)
			.IsRequired();

		builder
			.Property(x => x.Password)
			.IsRequired();
	}
}