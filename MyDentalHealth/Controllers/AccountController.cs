using Entity.Models.Dto;
using Entity.Models.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MyDentalHealth.Extentions;
using Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

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
			return View(new UserLoginDto());
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Auth(Login = false)]
		public IActionResult Singin([FromForm] UserLoginDto userLoginData)
		{
			if (ModelState.IsValid && userLoginData.Password is not null & userLoginData.Email is not null)
			{
				User? user = serviceManager.UserService.FindUserWithEmail(userLoginData.Email);
				if (user != null)
				{
					if (Entity.Models.User.User.isValidPassword(userLoginData.Password) && user.isPasswordMatch(Entity.Models.User.User.HashPassword(userLoginData.Password)))
					{
						HttpContext.Session.SetJson("UserId", user.Id);
						return Redirect("/MyHome/");
					}
					else
					{
						userLoginData.Password = "";
						ModelState.AddModelError("Password", "Wrong Password");
					}
				}
				else
					ModelState.AddModelError("Email", "Email Invalid");
			}

			return View(userLoginData);
		}
		[Auth]
		public async Task<IActionResult> Singout([FromQuery(Name = "mode")] string Mode = "NULL")
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
			bool Valid = true;
			if (newUserDto.Password is not null && newUserDto.ValidatePassword is not null && newUserDto.Password != newUserDto.ValidatePassword)
			{
				ModelState.AddModelError("ValidatePassword", "Validate Password Is Wrong");
				Valid = false;
			}
			else if (newUserDto.Password is not null && !Entity.Models.User.User.isValidPassword(newUserDto.Password))
			{
				ModelState.AddModelError("Password", "Password Invalid");
				Valid = false;
			}

			if (ModelState.IsValid && Valid)
			{
				User? user = serviceManager.UserService.FindUserWithEmail(newUserDto.Email);
				if (user is null)
				{
					serviceManager.UserService.CreateNewUser(newUserDto);
					return RedirectToAction("Singin");
				}
				else
					ModelState.AddModelError("Email", "This Email Using");
			}
			return View(newUserDto);
		}

		[Auth(Login = false)]
		public IActionResult Recovery()
		{
			return View(new RecoveryEmailDto());
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Auth(Login = false)]
		public IActionResult Recovery([FromForm] RecoveryEmailDto recoveryEmailDto)
		{
			User? user = serviceManager.UserService.FindUserWithEmail(recoveryEmailDto.Email);
			string timestamp = DateTime.Now.ToString();
			if (user is not null)
			{
				string Hash = "";
				using (SHA256 sha256 = SHA256.Create())
				{
					Hash = Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes($"{user.Password}{timestamp}{user.Id}")));
				}
				ModelState.AddModelError("Success", "Sended Mail");
				ModelState.AddModelError("Temp", $"http://localhost:5095/Account/ResetPassword?h={Hash}&t={Convert.ToBase64String(Encoding.UTF8.GetBytes(timestamp))}&u={user.Id}");
				return View(recoveryEmailDto);
			}
			ModelState.AddModelError("Failed", "This email is not used");

			return View(recoveryEmailDto);
		}

		[Auth(Login = false)]
		public IActionResult ResetPassword([FromQuery(Name = "h")] string Hash, [FromQuery(Name = "t")] string timestamp, [FromQuery(Name = "u")] string u)
		{
			return View(new RecoveryPasswordDto()
			{
				h = Hash,
				t = timestamp,
				u = u
			});
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Auth(Login = false)]
		public IActionResult ResetPassword([FromForm] RecoveryPasswordDto recoveryPasswordDto)
		{
			bool Valid = true;

			if (recoveryPasswordDto.Password is null)
			{
				ModelState.AddModelError("Err_Password", "Fill Password Field");
				Valid = false;

			}
			else if (!Entity.Models.User.User.isValidPassword(recoveryPasswordDto.Password))
			{
				ModelState.AddModelError("Err_Password", "Password Invalid");
				Valid = false;
			}
			if (recoveryPasswordDto.ValidatePassword is null)
			{
				ModelState.AddModelError("Err_ValidatePassword", "Fill ValidatePassword Field");
				Valid = false;

			}
			else if (recoveryPasswordDto.Password != recoveryPasswordDto.ValidatePassword)
			{
				ModelState.AddModelError("Err_ValidatePassword", "Validate Password Is Wrong");
				Valid = false;
			}

			if (ModelState.IsValid && Valid)
			{
				DateTime dateTime = DateTime.Parse(Encoding.UTF8.GetString(Convert.FromBase64String(recoveryPasswordDto.t)));

				if (DateTime.Now < dateTime.AddMinutes(180))
				{
					User? user = serviceManager.UserService.GetUserWithId(Convert.ToInt32(recoveryPasswordDto.u));
					if (user is not null)
					{
						string reHash = "";
						using (SHA256 sha256 = SHA256.Create())
						{
							reHash = Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes($"{user.Password}{dateTime}{recoveryPasswordDto.u}")));
						}
						if (recoveryPasswordDto.h == reHash)
						{
							user.Password = Entity.Models.User.User.HashPassword(recoveryPasswordDto.Password);
							serviceManager.UserService.UpdateUser(user);
						}
						return RedirectToAction("Singin");
					}
				}
			}
			return View(recoveryPasswordDto);
		}

	}
}
