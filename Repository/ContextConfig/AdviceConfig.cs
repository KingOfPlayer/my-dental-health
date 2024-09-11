using Entity.Models.Target;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Models.Advice;

namespace Repository.ContextConfig
{
	public class AdviceConfig : IEntityTypeConfiguration<Advice>
	{
		public void Configure(EntityTypeBuilder<Advice> builder)
		{
			builder.HasData(
				new Advice() { Id = 1, Name = "1" ,Description = "1"},
				new Advice() { Id = 2, Name = "2" ,Description = "2"},
				new Advice() { Id = 3, Name = "3" ,Description = "3"},
				new Advice() { Id = 4, Name = "4" ,Description = "4"},
				new Advice() { Id = 5, Name = "5" ,Description = "5"},
				new Advice() { Id = 6, Name = "6" ,Description = "6"},
				new Advice() { Id = 7, Name = "7" ,Description = "7"},
				new Advice() { Id = 8, Name = "8" ,Description = "8"}
				);
		}
	}
}
