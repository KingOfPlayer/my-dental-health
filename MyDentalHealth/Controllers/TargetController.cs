using AutoMapper;
using Entity.Models.Dto;
using Entity.Models.Target;
using Entity.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyDentalHealth.Extentions;
using Service;
using Service.Interfaces;

namespace MyDentalHealth.Controllers
{
    [Auth]
    public class TargetController : Controller
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

		public TargetController(IServiceManager serviceManager, IMapper mapper)
		{
			this.serviceManager = serviceManager;
			this.mapper = mapper;
		}

		public void SetViewBagTargetContent()
		{
			ViewBag.TargetPiroities = new SelectList(serviceManager.TargetService.GetTargetPiroities(), "Id", "Name", "1");
			ViewBag.TargetPeriodTypes = new SelectList(serviceManager.TargetService.GetTargetPeriodTypes(), "Id", "Name", "1");
		}

        public IActionResult CreateTarget()
        {
			SetViewBagTargetContent();
			return View(new TargetDto());
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
        public IActionResult CreateTarget([FromForm] TargetDto targetDto, [FromQuery(Name = "c")] string url)
        {
			var Valid = true;
			if (ModelState.IsValid && Valid)
			{
				Target target = mapper.Map<Target>(targetDto);
				target.UserId = HttpContext.Session.GetJson<int>("UserId");
				serviceManager.TargetService.CreateTarget(target);
				return Redirect(url);
			}
			SetViewBagTargetContent();
			return View(targetDto);
        }

        public IActionResult TargetDetails([FromQuery(Name = "TargetId")] int TargetId)
		{
			return View(TargetId);
        }

        public IActionResult UpdateTarget([FromQuery(Name = "TargetId")] int TargetId)
        {
            return View(TargetId);
        }

        public IActionResult CreateTargetStatus([FromQuery(Name = "TargetId")] int TargetId)
		{
			return View(TargetId);
        }
    }
}
