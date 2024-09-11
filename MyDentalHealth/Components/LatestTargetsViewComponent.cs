using Entity.Models.Target;
using Entity.Models.Target.Status;
using Entity.Models.User;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Linq;

namespace MyDentalHealth.Components
{
	public class LatestTargetsViewComponent : ViewComponent
	{
		private readonly IServiceManager serviceManager;

		public LatestTargetsViewComponent(IServiceManager serviceManager)
		{
			this.serviceManager = serviceManager;
		}

		public IViewComponentResult Invoke(User user)
		{
			int targetStatuses = serviceManager.TargetService.GetUsersTargetStatus(user).Where(ts => DateTime.Now.AddDays(-7) < ts.Attime).Count();
			return View(targetStatuses);
		}
	}
}
