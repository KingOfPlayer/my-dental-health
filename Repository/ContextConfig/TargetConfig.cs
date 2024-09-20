using Entity.Models.Target;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
					Count = 1,
					PeriodTime = DateTime.Now.AddDays(-7)
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
					PeriodTime = DateTime.Now.AddDays(-50)
				});
		}
	}
}
