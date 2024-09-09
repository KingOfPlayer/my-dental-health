using Entity.Models.Target;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.ContextConfig
{
	public class TargetPeriodTypeConfig : IEntityTypeConfiguration<TargetPeriodType>
	{
		public void Configure(EntityTypeBuilder<TargetPeriodType> builder)
		{
			builder.HasData(
				new TargetPeriodType() { Id = 1, Name = "Daily" },
				new TargetPeriodType() { Id = 2, Name = "Weekly" },
				new TargetPeriodType() { Id = 3, Name = "Monthly" },
				new TargetPeriodType() { Id = 4, Name = "Yearly" }
				);
		}
	}
}
