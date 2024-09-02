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
        public IActionResult Singin()
        {
            return View(new UserLoginDataDto());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Auth(Login=false)]
        public IActionResult Singin([FromForm] UserLoginDataDto userLoginData)
        {
            if (ModelState.IsValid && userLoginData.Password is not null & userLoginData.Email is not null)
            {
				User? user = serviceManager.UserService.FindUserWithEmail(userLoginData.Email);
				if (user != null)
				{
                    if (Entity.Models.User.User.isValidPassword(userLoginData.Password) && user.isPasswordMatch(Entity.Models.User.User.HashPassword(userLoginData.Password)))
                    {
                        HttpContext.Session.SetJson("UserId", user.Id);
                        return Redirect("/Home");
                    }
                    else
                    {
                        userLoginData.Password = "";
						ModelState.AddModelError("Err_Password", "Wrong Password");
                    }
                }
                else
                    ModelState.AddModelError("Err_Email", "Email Invalid");
            }
            else
            {
				if(userLoginData.Password is null)
                    ModelState.AddModelError("Err_Password", "Fill Password Field");
				if(userLoginData.Email is null)
                    ModelState.AddModelError("Err_Email", "Fill Email Field");

			}

			return View(userLoginData);
		}
        [Auth]
        public async Task<IActionResult> Singout([FromQuery(Name="mode")] string Mode = "NULL")
		{
			HttpContext.Session.Remove("UserId");
			if (Mode.Equals("Secure"))
			{
				await HttpContext.SignOutAsync();
				HttpContext.Session.Clear();
				await HttpContext.Session.CommitAsync();

			}
			return Redirect("/Home");
        }

        [Auth(Login = false)]
        public IActionResult SingUp()
        {
            return View(new NewUserDto());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Auth(Login = false)]
        public IActionResult Singup([FromForm] NewUserDto newUserDto)
        {
            bool Valid=true;
			if (newUserDto.Name is null)
			{
				ModelState.AddModelError("Err_Name", "Fill Name Field");
				Valid=false;
			}
			if (newUserDto.Surname is null) 
            { 
				ModelState.AddModelError("Err_Surname", "Fill Surname Field");
				Valid = false;
			}
			if (newUserDto.Email is null)
			{
			    ModelState.AddModelError("Err_Email", "Fill Email Field");
				Valid = false;
			}
			if (newUserDto.Password is null)
			{
			    ModelState.AddModelError("Err_Password", "Fill Password Field");
				Valid = false;
			}
			if (newUserDto.ValidatePassword is null)
			{
			    ModelState.AddModelError("Err_ValidatePassword", "Fill ValidatePassword Field");
				Valid = false;
			}
			if (newUserDto.Password != newUserDto.ValidatePassword)
			{
			    ModelState.AddModelError("Err_ValidatePassword", "Validate Password Is Wrong");
				Valid = false;
			}
			else if (!Entity.Models.User.User.isValidPassword(newUserDto.Password))
			{
			    ModelState.AddModelError("Err_Password", "Password Invalid");
				Valid = false;
			}

			if (ModelState.IsValid && Valid)
            {
				User? user = serviceManager.UserService.FindUserWithEmail(newUserDto.Email);
                if(user is null)
                {
					serviceManager.UserService.CreateNewUser(newUserDto);
					return RedirectToAction("Singin");
				}
				else
					ModelState.AddModelError("Err_Email", "This Email Using");
			}
			return View(newUserDto);
        }
    }
}
