using Microsoft.AspNetCore.Mvc;

namespace MyDentalHealth.Controllers
{
	public class AccountController : Controller
	{
		public IActionResult Index()
		{
			return RedirectToAction("Home");
		}
	}
}
