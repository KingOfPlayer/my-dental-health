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
    public class TargetPeriodTypeConfig : IEntityTypeConfiguration<TargetPeriodType>
	{
		public void Configure(EntityTypeBuilder<TargetPeriodType> builder)
		{
			builder.HasData(
				new TargetPeriodType() { Id = 1, Name = "High", Target = new List<Target>() },
				new TargetPeriodType() { Id = 2, Name = "Medium", Target = new List<Target>()},
				new TargetPeriodType() { Id = 3, Name = "Low", Target = new List<Target>() }
				);
		}
	}
}
