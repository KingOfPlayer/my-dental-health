using AutoMapper;
using Entity.Models.Dto;
using Entity.Models.Dto.Profile;
using Entity.Models.User;
using Microsoft.AspNetCore.Mvc;
using MyDentalHealth.Extentions;
using Services.Interfaces;

namespace MyDentalHealth.Controllers
{
	[Auth(Roles = "User")]
	public class ProfileController : Controller
	{
		private readonly IServiceManager serviceManager;
		private readonly IMapper mapper;

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

		public List<UserRole>? Roles
		{
			get
			{
				int UserId = HttpContext.Session.GetJson<int>("UserId");
				if (UserId != 0)
				{
					return serviceManager?.UserService.GetUserRolesWithUserId(UserId);
				}
				return null;
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
			return View(new NameUpdateDto() { Name = User.Name});
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Name([FromForm] NameUpdateDto nameUpdateDto)
		{
			if (ModelState.IsValid)
			{
				User _user = User;
				mapper.Map(nameUpdateDto, _user);
				serviceManager.UserService.UpdateUser(_user);
				return RedirectToAction("");
			}
			return View(nameUpdateDto);
        }

        public IActionResult Surname()
        {
            return View(new SurnameUpdateDto() { Surname = User.Surname });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Surname([FromForm] SurnameUpdateDto surnameUpdateDto)
		{
			if (ModelState.IsValid)
			{
				User _user = User;
				mapper.Map(surnameUpdateDto, _user);
				serviceManager.UserService.UpdateUser(_user);
				return RedirectToAction("");
			}
			return View(surnameUpdateDto);
		}

        public IActionResult Birthday()
		{
			return View(new BirthdayDateUpdateDto() { BirthdayDate = User.BirthdayDate });
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Birthday([FromForm] BirthdayDateUpdateDto birthdayDateUpdateDto)
		{
			if (ModelState.IsValid)
			{
				User _user = User;
				mapper.Map(birthdayDateUpdateDto, _user);
				serviceManager.UserService.UpdateUser(_user);
				return RedirectToAction("");
			}
			return View(birthdayDateUpdateDto);
		}

		public IActionResult Email()
		{
			return View(new EmailUpdateDto() { Email = User.Email });
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Email([FromForm] EmailUpdateDto emailUpdateDto)
		{
			if (ModelState.IsValid)
			{
				User _user = User;
				mapper.Map(emailUpdateDto, _user);
				serviceManager.UserService.UpdateUser(_user);
				return RedirectToAction("");
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
			if (passwordUpdateDto.CurrentPassword is not null && User.HashPassword(passwordUpdateDto.CurrentPassword) != User.Password)
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
				User _user = User;
				passwordUpdateDto.Password = User.HashPassword(passwordUpdateDto.Password);
				mapper.Map(passwordUpdateDto, _user);
				serviceManager.UserService.UpdateUser(_user);
				return RedirectToAction("");
			}
			return View(passwordUpdateDto);
		}
	}
}
