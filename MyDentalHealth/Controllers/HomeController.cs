using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using MyDentalHealth.Extentions;
using Services.Interfaces;

namespace MyDentalHealth.Controllers
{
	public class HomeController : Controller
	{
		IServiceManager serviceManager;

		public HomeController(IServiceManager serviceManager)
		{
			this.serviceManager = serviceManager;
		}

		public IActionResult Index()
		{
            return View();
		}

		[Auth]
		public IActionResult MyInfo()
		{
			return View();
		}
	}
}
