using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace MyDentalHealth.Components
{
	public class AdviceViewComponent : ViewComponent
	{
		private readonly IServiceManager serviceManager;

		public AdviceViewComponent(IServiceManager serviceManager)
		{
			this.serviceManager = serviceManager;
		}

		public IViewComponentResult Invoke()
		{
			ViewBag.Advice = serviceManager.AdviceService.GetRandomAdvice();

			return View();
		}
	}
}
