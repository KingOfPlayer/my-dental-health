using Entity.Models.Dto;
using Entity.Models.Target;
using Entity.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service.Interfaces;

namespace MyDentalHealth.Components
{
	public class NewTargetFormViewComponent : ViewComponent
	{
		private readonly IServiceManager serviceManager;

		public NewTargetFormViewComponent(IServiceManager serviceManager)
		{
			this.serviceManager = serviceManager;
		}

		public void SetViewBagTargetContent()
		{
			ViewBag.TargetPiroities = new SelectList(serviceManager.TargetService.GetTargetPiroities(), "Id", "Name", "1");
			ViewBag.TargetPeriodTypes = new SelectList(serviceManager.TargetService.GetTargetPeriodTypes(), "Id", "Name", "1");
		}

		public IViewComponentResult Invoke()
		{
			SetViewBagTargetContent();
			return View(new TargetDto());
		}
	}
}
