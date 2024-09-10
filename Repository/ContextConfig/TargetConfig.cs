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
	public class TargetConfig : IEntityTypeConfiguration<Target>
	{
		public void Configure(EntityTypeBuilder<Target> builder)
		{
			builder.HasData(
				new Target()
				{
					Id = 1,
					UserId = 1,
					Name = "My Target Test",
					Description = "My Description",
					TargetPiroityId = 1,
					TargetPeriodTypeId = 1,
					PeriodLength = 1,
					Count = 1
				},
				new Target()
				{
					Id = 2,
					UserId = 1,
					Name = "My Target Test2",
					Description = "My Description",
					TargetPiroityId = 1,
					TargetPeriodTypeId = 2,
					PeriodLength = 2,
					Count = 10,
					PeriodTime = new DateTime(2024, 6, 15)
				});
		}
	}
}
