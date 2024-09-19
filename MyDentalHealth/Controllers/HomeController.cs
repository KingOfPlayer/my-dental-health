using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

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
	}
}
