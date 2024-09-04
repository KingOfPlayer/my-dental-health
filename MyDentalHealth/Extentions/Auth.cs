using Entity.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Services.Interfaces;

namespace MyDentalHealth.Extentions
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
	public class Auth : Attribute, IActionFilter
	{
		public bool Login = true;
		public string RedirectController = "Home";
		public string RedirectAction = "Index";
		public string Roles = "";

		public void OnActionExecuted(ActionExecutedContext context)
		{
			return;
		}

		public void OnActionExecuting(ActionExecutingContext context)
		{
			int UserId = context.HttpContext.Session.GetJson<int>("UserId");
			if (Login == (UserId != 0))
			{
				if (Roles != "")
				{
					List<string> roles = Roles.Split(',').ToList();
					IServiceManager? serviceManager = context.HttpContext.RequestServices.CreateScope().ServiceProvider.GetService<IServiceManager>();

					List<UserRole>? userRoles = serviceManager?.UserService.GetUserRolesWithUserId(UserId);
					if (userRoles != null && roles.All(r => userRoles.Any(ur => ur.Name.Equals(r))))
						return;
				}
				else
					return;
			}
			context.Result = new RedirectToActionResult(RedirectAction, RedirectController, null);
		}
	}
}
