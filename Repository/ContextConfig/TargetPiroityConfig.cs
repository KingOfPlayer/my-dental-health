using Entity.Models.Target;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
