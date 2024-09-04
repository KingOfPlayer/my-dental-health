using Microsoft.AspNetCore.Mvc;

namespace MyDentalHealth.Controllers
{
	public class ProfileController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
