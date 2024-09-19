using AutoMapper;
using Entity.Models.Dto.Profile;
using Entity.Models.User;
using Microsoft.AspNetCore.Mvc;
using MyDentalHealth.Extentions;
using Service.Interfaces;

namespace MyDentalHealth.Controllers
{
	[Auth(Roles = "User")]
	public class ProfileController : Controller
	{
		private readonly IServiceManager serviceManager;
		private readonly IMapper mapper;

		private User? user;
		public new User? User
		{
			get
			{
				if (user == null)
				{
					int UserId = HttpContext.Session.GetJson<int>("UserId");
					if (UserId != 0)
					{
						user = serviceManager?.UserService.GetUserWithId(UserId);
					}
				}
				return user;
			}
		}

		private List<UserRole>? roles;
		public List<UserRole>? Roles
		{
			get
			{
				if (roles == null)
				{
					int UserId = HttpContext.Session.GetJson<int>("UserId");
					if (UserId != 0)
					{
						roles = serviceManager?.UserService.GetUserRolesWithUserId(UserId);
						return roles;
					}
				}
				return roles;
			}
		}

		public ProfileController(IServiceManager serviceManager, IMapper mapper)
		{
			this.serviceManager = serviceManager;
			this.mapper = mapper;
		}

		public IActionResult Index()
		{
			return View();

		}

		public IActionResult Name()
		{
			return View(new NameUpdateDto() { Name = User!.Name });
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Name([FromForm] NameUpdateDto nameUpdateDto)
		{
			if (ModelState.IsValid)
			{
				User _user = User!;
				mapper.Map(nameUpdateDto, _user);
				serviceManager.UserService.UpdateUser(_user);
				return RedirectToAction("");
			}
			return View(nameUpdateDto);
		}

		public IActionResult Surname()
		{
			return View(new SurnameUpdateDto() { Surname = User!.Surname });
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Surname([FromForm] SurnameUpdateDto surnameUpdateDto)
		{
			if (ModelState.IsValid)
			{
				User _user = User!;
				mapper.Map(surnameUpdateDto, _user);
				serviceManager.UserService.UpdateUser(_user);
				return RedirectToAction("");
			}
			return View(surnameUpdateDto);
		}

		public IActionResult Birthday()
		{
			return View(new BirthdayDateUpdateDto() { BirthdayDate = User!.BirthdayDate });
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Birthday([FromForm] BirthdayDateUpdateDto birthdayDateUpdateDto)
		{
			if (ModelState.IsValid)
			{
				User _user = User!;
				mapper.Map(birthdayDateUpdateDto, _user);
				serviceManager.UserService.UpdateUser(_user);
				return RedirectToAction("");
			}
			return View(birthdayDateUpdateDto);
		}

		public IActionResult Email()
		{
			return View(new EmailUpdateDto() { Email = User!.Email });
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Email([FromForm] EmailUpdateDto emailUpdateDto)
		{
			if (User!.Email == emailUpdateDto.Email)
				ModelState.AddModelError("Email", "Enter different email");
			else if (ModelState.IsValid)
			{
				User? t_serchedUser = await serviceManager.UserService.FindUserWithEmail(emailUpdateDto.Email);
				if (t_serchedUser is null)
				{
					User _user = User!;
					mapper.Map(emailUpdateDto, _user);
					serviceManager.UserService.UpdateUser(_user);
					return RedirectToAction("");
				}
				else
					ModelState.AddModelError("Email", "This email using");
			}
			return View(emailUpdateDto);
		}

		public IActionResult Password()
		{
			return View(new PasswordUpdateDto());
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Password([FromForm] PasswordUpdateDto passwordUpdateDto)
		{

			bool Valid = true;
			if (passwordUpdateDto.CurrentPassword is not null && User.HashPassword(passwordUpdateDto.CurrentPassword) != User!.Password)
			{
				ModelState.AddModelError("CurrentPassword", "Current Password Is Wrong");
				Valid = false;
			}
			if (passwordUpdateDto.Password is not null && passwordUpdateDto.ValidatePassword is not null && passwordUpdateDto.Password != passwordUpdateDto.ValidatePassword)
			{
				ModelState.AddModelError("ValidatePassword", "Validate Password Is Wrong");
				Valid = false;
			}
			else if (passwordUpdateDto.Password is not null && !User.isValidPassword(passwordUpdateDto.Password))
			{
				ModelState.AddModelError("Password", "New Password Invalid");
				Valid = false;
			}
			if (ModelState.IsValid && Valid)
			{
				User _user = User!;
				passwordUpdateDto.Password = User.HashPassword(passwordUpdateDto.Password!);
				mapper.Map(passwordUpdateDto, _user);
				serviceManager.UserService.UpdateUser(_user);
				return RedirectToAction("");
			}
			return View(passwordUpdateDto);
		}
	}
}
