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
				new TargetPeriodType() { Id = 1, Name = "Day" },
				new TargetPeriodType() { Id = 2, Name = "Week" },
				new TargetPeriodType() { Id = 3, Name = "Month" },
				new TargetPeriodType() { Id = 4, Name = "Year" }
				);
		}
	}
}
