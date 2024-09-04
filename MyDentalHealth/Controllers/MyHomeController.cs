using Microsoft.AspNetCore.Mvc;
using MyDentalHealth.Extentions;

namespace MyDentalHealth.Controllers
{
	[Auth(Roles = "User")]
	public class MyHomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
