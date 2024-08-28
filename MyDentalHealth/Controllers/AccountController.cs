using Entity.Models.Dto;
using Entity.Models.User;
using Microsoft.AspNetCore.Mvc;
using MyDentalHealth.Extentions;
using Services.Interfaces;

namespace MyDentalHealth.Controllers
{
	public class AccountController : Controller
	{
        private readonly IServiceManager serviceManager;

        public AccountController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        public IActionResult Index()
		{
			return RedirectToAction("Home");
		}

        public IActionResult Login()
        {
            return View(new UserLoginDataDto());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public string Login([FromForm] UserLoginDataDto userLoginData)
        {
            if (HttpContext.Request.Cookies[".mdh.Session"] == null)
                HttpContext.Session.InitSession();
            User? user = HttpContext.Session.GetJson<User>("User");
            if (user == null)
            {
                user = serviceManager.UserService.Login(userLoginData);
                if (user != null)
                {
                    HttpContext.Session.SetJson<User>("User", user);
                    return $"OK";
                }
            }
            return $"NOT OK";
        }
    }
}
