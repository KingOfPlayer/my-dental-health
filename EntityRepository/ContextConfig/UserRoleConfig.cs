using Entity.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityRepository.ContextConfig
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
