using Entity.Models.Dto;
using Entity.Models.Target;
using Entity.Models.Target.Status;
using Entity.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
