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

		public new User? User
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

		public TargetController(IServiceManager serviceManager, IMapper mapper)
		{
			this.serviceManager = serviceManager;
			this.mapper = mapper;
		}

		public IActionResult Index()
        {
			List<Target> targets = serviceManager.TargetService.GetUserTargets(User!);
            return View(targets);
        }

        public IActionResult CreateTarget()
        {
			ViewBag.TargetPiroities = new SelectList(serviceManager.TargetService.GetTargetPiroities(), "Id", "Name", "1");
			ViewBag.TargetPeriodTypes = new SelectList(serviceManager.TargetService.GetTargetPeriodTypes(), "Id", "Name", "1"); ;

			return View(new TargetDto());
        }
		[HttpPost]
		[ValidateAntiForgeryToken]
        public IActionResult CreateTarget([FromForm] TargetDto targetDto)
        {
			var Valid = true;
			if(ModelState.IsValid && Valid)
				return View(new TargetDto());
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

        public IActionResult NewTargetStatus([FromQuery(Name = "TargetId")] int TargetId)
		{
			return View(TargetId);
        }
    }
}
