using Entity.Models.User;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace MyDentalHealth.Components
{
	public class TargetStatusesViewComponent : ViewComponent
	{
		private readonly IServiceManager serviceManager;

		public TargetStatusesViewComponent(IServiceManager serviceManager)
		{
			this.serviceManager = serviceManager;
		}

		public async Task<IViewComponentResult> InvokeAsync(User user)
		{

			await serviceManager.TargetService.UpdateTargetCheckDates(user.Id);
			ViewBag.targets = await serviceManager.TargetService.GetUserTargets(user);
			ViewBag.targetStatuses = serviceManager.TargetService.GetUsersTargetStatus(user).ToList();
			return View();
		}
	}
}
