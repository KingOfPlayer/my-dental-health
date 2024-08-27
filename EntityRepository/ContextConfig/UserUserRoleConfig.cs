﻿using Entity.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityRepository.ContextConfig
{
	public class UserUserRoleConfig : IEntityTypeConfiguration<UserUserRole>
	{
		public void Configure(EntityTypeBuilder<UserUserRole> builder)
		{
			builder.HasKey(r => new { r.UserId, r.UserRoleId });

			builder.HasOne(r => r.User)
				   .WithMany(u => u.Roles)
				   .HasForeignKey(r => r.UserId);

			builder.HasOne(r => r.UserRole)
				   .WithMany(u => u.Users)
				   .HasForeignKey(r => r.UserRoleId);

			builder.HasData(
				new UserUserRole() {UserId = 1, UserRoleId = 1}
				);
		}
	}
}
