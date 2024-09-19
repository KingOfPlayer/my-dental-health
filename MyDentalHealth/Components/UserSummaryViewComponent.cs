using Entity.Models.User;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace MyDentalHealth.Components
{
	public class UserSummaryViewComponent : ViewComponent
	{
		private readonly IServiceManager serviceManager;

		public UserSummaryViewComponent(IServiceManager serviceManager)
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
