using Entity.Models.Target;
using Entity.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ContextConfig
{
    public class UserConfig : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasData(
				new User() { 
					Id = 1,
					Name = "admin",
					Surname = "admin",
					Email="admin@admin.com", 
					Password="1234", 
					BirthdayDate = new DateTime(1999,9,9), 
					Target = new HashSet<Target>(), 
					Logins = new HashSet<UserLogin>(), 
					Roles=new HashSet<UserUserRole>()
				});
		}
	}
}
