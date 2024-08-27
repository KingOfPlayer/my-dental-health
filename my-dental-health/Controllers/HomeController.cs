using Microsoft.AspNetCore.Mvc;

namespace my_dental_health.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
