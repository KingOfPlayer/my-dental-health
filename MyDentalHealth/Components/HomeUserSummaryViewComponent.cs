using Entity.Models.Target;
using Entity.Models.Target.Status;
using Entity.Models.User;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Linq;

namespace MyDentalHealth.Components
{
	public class HomeUserSummaryViewComponent : ViewComponent
	{
		private readonly IServiceManager serviceManager;

		public HomeUserSummaryViewComponent(IServiceManager serviceManager)
		{
			this.serviceManager = serviceManager;
		}

		public IViewComponentResult Invoke(User user)
		{
			ViewBag.targetStatuses = serviceManager.TargetService.GetUsersTargetStatus(user).Where(ts => DateTime.Now.AddDays(-7) < ts.Attime).ToList();

            return View();
		}
	}
}
