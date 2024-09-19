using Entity.Models.Target.Status;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.ContextConfig
{
	public class TargetStatusConfig : IEntityTypeConfiguration<TargetStatus>
	{
		public void Configure(EntityTypeBuilder<TargetStatus> builder)
		{
			builder.HasData(
				new TargetStatus() { Id = 1, TargetId = 1, Attime = DateTime.Now.AddDays(-1), Minutes = 0, Second = 10 },
				new TargetStatus() { Id = 2, TargetId = 1, Attime = DateTime.Now.AddDays(-15), Minutes = 0, Second = 10 }
				);
		}
	}
}
