using Entity.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.ContextConfig
{
	public class UserConfig : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasData(
				new User()
				{
					Id = 1,
					Name = "admin",
					Surname = "admin",
					Email = "admin@admin.com",
					Password = User.HashPassword("Admin1234"),
					BirthdayDate = new DateTime(1999, 9, 9)
				});
		}
	}
}
