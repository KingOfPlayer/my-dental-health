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
	internal class TargetPiroityConfig : IEntityTypeConfiguration<TargetPiroity>
	{
		public void Configure(EntityTypeBuilder<TargetPiroity> builder)
		{
			builder.HasData(
				new TargetPiroity() { Id = 1, Name = "High" },
				new TargetPiroity() { Id = 2, Name = "Medium" },
				new TargetPiroity() { Id = 3, Name = "Low" }
				);
		}
	}
}
