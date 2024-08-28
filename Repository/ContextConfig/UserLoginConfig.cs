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
    public class UserLoginConfig : IEntityTypeConfiguration<UserLogin>
	{
		public void Configure(EntityTypeBuilder<UserLogin> builder)
		{
			builder.HasKey(ul => new { ul.Id});

			builder.HasIndex(ul => ul.Token).IsUnique();
		}
	}
}
