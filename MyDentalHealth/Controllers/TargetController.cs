using AutoMapper;
using Entity.Models.Dto;
using Entity.Models.Target;
using Entity.Models.Target.Status;
using Entity.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyDentalHealth.Extentions;
using Service;
using Service.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;

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

		[HttpPost]
		[ValidateAntiForgeryToken]
        public IActionResult CreateTarget([FromForm] TargetDto targetDto)
        {
			if (ModelState.IsValid)
			{
				Target target = mapper.Map<Target>(targetDto);
				target.UserId = HttpContext.Session.GetJson<int>("UserId");
				serviceManager.TargetService.CreateTarget(target);
				return Json(new { success = true , clear = true});
			}
			var errors = ModelState.Where(err => err.Value.Errors.Count() > 0).Select(err => new {Key = err.Key,errs= err.Value.Errors.Select(x => x.ErrorMessage)});
			return Json(new { success = false , errors });
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> CreateTargetStatus([FromForm] TargetStatusDto targetStatusDto, IFormFile? File)
		{
			if (ModelState.IsValid)
			{
				Target? target = (await serviceManager.TargetService.GetUserTargets(User!.Id)).Where(t => t.Id.Equals(targetStatusDto.TargetId)).FirstOrDefault();
				if (target is not null) {

					TargetStatus targetStatus = mapper.Map<TargetStatus>(targetStatusDto);
					if (File is not null)
					{
						string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", File.FileName);

						using (var steam = new FileStream(path, FileMode.Create))
						{
							await File.CopyToAsync(steam);
						}
						targetStatus.ImgHash = File.FileName;
					}

					serviceManager.TargetService.CreateTargetStatus(targetStatus);
					return Json(new { success = true, clear = true });
				}
			}
			var errors = ModelState.Where(err => err.Value.Errors.Count() > 0).Select(err => new { Key = err.Key, errs = err.Value.Errors.Select(x => x.ErrorMessage) });
			return Json(new { success = false, errors });
		}
		
		public async Task<IActionResult> RemoveTarget([FromQuery(Name = "TargetId")] int TargetId,[FromQuery(Name = "Validate")] bool Validate)
		{
			var Target = (await serviceManager.TargetService.GetUserTargets(User!.Id)).Any(ts => ts.Id.Equals(TargetId));
			if (!Target)
			{
				return Json(new { success = false });
			}
			var TargetStatus = serviceManager.TargetService.GetAllTargetStatus(TargetId).ToList(); 
			if (TargetStatus.Any())
			{
				if (!Validate)
				{
					return Json(new { success = false });
				}
				serviceManager.TargetService.RemoveTargetStatus(TargetStatus);
			}
			await serviceManager.TargetService.RemoveTarget(TargetId,User!.Id);
			return Json(new { success = true});
		}
		/*
		public IActionResult TargetDetails([FromQuery(Name = "TargetId")] int TargetId)
		{
			return View(TargetId);
        }

        public IActionResult UpdateTarget([FromQuery(Name = "TargetId")] int TargetId, [FromQuery(Name = "Validate")] bool Validate)
		{
			if (Validate)
			{
				return Json(new { success = true});
			}
			return Json(new { success = false});
		}
		*/

    }
}
