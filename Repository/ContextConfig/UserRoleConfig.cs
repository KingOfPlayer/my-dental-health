using Entity.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.ContextConfig
{
	public class UserRoleConfig : IEntityTypeConfiguration<UserRole>
	{
		public void Configure(EntityTypeBuilder<UserRole> builder)
		{
			builder.HasData(
				new UserRole() { Id = 1, Name = "Admin" },
				new UserRole() { Id = 2, Name = "User" }
				);
		}
	}
}
