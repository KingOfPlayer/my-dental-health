using Entity.Models.Target.Status;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace MyDentalHealth.Components
{
	public class NewTargetStatusFormViewComponent : ViewComponent
	{
		private readonly IServiceManager serviceManager;

		public NewTargetStatusFormViewComponent(IServiceManager serviceManager)
		{
			this.serviceManager = serviceManager;
		}

		public IViewComponentResult Invoke(int TargetId)
		{
			ViewBag.TargetId = TargetId;
			return View(new TargetStatusDto());
		}
	}
}
