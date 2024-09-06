using Entity.Models.User;
using Microsoft.AspNetCore.Mvc;
using MyDentalHealth.Extentions;
using Service.Interfaces;

namespace MyDentalHealth.Controllers
{
	public class HomeController : Controller
	{
		IServiceManager serviceManager;

        public User? User
        {
            get
            {
                int UserId = HttpContext.Session.GetJson<int>("UserId");
                if (UserId != 0)
                {
                    return serviceManager?.UserService.GetUserWithId(UserId);
                }
                return null;
            }
        }

        public HomeController(IServiceManager serviceManager)
		{
			this.serviceManager = serviceManager;
		}

		public IActionResult Index()
		{
            if(User is not null)
            {
                return RedirectToAction("Index","MyHome");
            }

            return View();
		}

		[Auth]
		public IActionResult MyInfo()
		{
			return View();
		}
	}
}
