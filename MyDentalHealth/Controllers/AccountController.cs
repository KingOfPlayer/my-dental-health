using Entity.Models.Dto;
using Entity.Models.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MyDentalHealth.Extentions;
using Services.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace MyDentalHealth.Controllers
{
	public class AccountController : Controller
	{
        private readonly IServiceManager serviceManager;

        public AccountController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        [Auth(Login = false)]
        public IActionResult Login()
        {
            return View(new UserLoginDataDto());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Auth(Login=false)]
        public async Task<IActionResult> Login([FromForm] UserLoginDataDto userLoginData)
        {
            if (ModelState.IsValid && userLoginData.Password is not null & userLoginData.Email is not null)
            {
				User? user = await serviceManager.UserService.FindUserWithEmail(userLoginData.Email);
				if (user != null)
				{
                    if (Entity.Models.User.User.isValidPassword(userLoginData.Password) && user.isPasswordMatch(Entity.Models.User.User.HashPassword(userLoginData.Password)))
                    {

                        List<UserRole> roles = await serviceManager.UserService.GetUserRoles(user);
                        HttpContext.Session.SetJson("User", user);
                        HttpContext.Session.SetJson("Roles", roles);
                        return Redirect("/Home");
                    }
                    else
                    {
                        userLoginData.Password = "";
						ModelState.AddModelError("Err_password", "Wrong Password");
                    }
                }
                else
                    ModelState.AddModelError("Err_email", "Email Invalid");
            }
            else
            {
				if(userLoginData.Password is null)
                    ModelState.AddModelError("Err_password", "Fill Password Field");
				if(userLoginData.Email is null)
                    ModelState.AddModelError("Err_email", "Fill Email Field");

			}

			return View(userLoginData);
		}
        [Auth()]
        public async Task<IActionResult> Logout([FromQuery(Name="mode")] string Mode = "NULL")
		{
			HttpContext.Session.Remove("User");
			HttpContext.Session.Remove("Roles");
			if (Mode.Equals("Secure"))
			{
				await HttpContext.SignOutAsync();
				HttpContext.Session.Clear();
				await HttpContext.Session.CommitAsync();

			}
			return Redirect("/Home");
        }
    }
}
