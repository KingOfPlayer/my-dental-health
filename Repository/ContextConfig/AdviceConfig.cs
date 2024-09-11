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
				new Advice() { 
					Id = 1, 
					Name = "Brush Twice Daily",
					Description = "Brushing your teeth twice a day with fluoride toothpaste helps remove plaque and bacteria, keeping your teeth and gums healthy."
				},
				new Advice() { 
					Id = 2, 
					Name = "Floss Daily",
					Description = "Flossing once a day removes food particles and plaque from between teeth, areas a toothbrush can't reach, reducing the risk of gum disease and cavities."
				},
				new Advice() { 
					Id = 3, 
					Name = "Use Mouthwash",
					Description = "Mouthwash can help kill bacteria, freshen breath, and strengthen enamel, especially when using fluoride or antiseptic mouthwashes."
				},
				new Advice() { 
					Id = 4, 
					Name = "Limit Sugary Foods and Drinks",
					Description = "Excess sugar in your diet fuels bacteria that produce acid, leading to tooth decay. Avoid sugary snacks and beverages, especially between meals."
				},
				new Advice() { 
					Id = 5, 
					Name = "Stay Hydrated",
					Description = "Drinking water helps wash away food particles and bacteria, and staying hydrated ensures your mouth produces enough saliva to protect your teeth."
				},
				new Advice() { 
					Id = 6, 
					Name = "Visit Your Dentist Regularly",
					Description = "Regular dental check-ups and cleanings (every 6 months) allow for early detection of problems and professional plaque removal."
				},
				new Advice() { 
					Id = 7, 
					Name = "Don’t Use Tobacco Products",
					Description = "Smoking and using tobacco can lead to gum disease, tooth decay, and even oral cancer. Avoiding these products is key to long-term oral health."
				},
				new Advice() { 
					Id = 8, 
					Name = "Use a Soft-Bristle Toothbrush",
					Description = "A soft-bristle toothbrush is gentle on your gums and enamel, reducing the risk of erosion or irritation. Replace your toothbrush every 3-4 months."
				},
				new Advice() { 
					Id = 9, 
					Name = "Eat a Balanced Diet",
					Description = "Foods rich in calcium, vitamin D, and phosphorus help strengthen teeth and bones, while crunchy fruits and vegetables stimulate saliva production."
				},
				new Advice() { 
					Id = 10, 
					Name = "Wear a Mouthguard for Sports",
					Description = "If you play contact sports, wearing a mouthguard helps protect your teeth from injury or trauma, reducing the risk of chipped or broken teeth."
				});
		}
	}
}
