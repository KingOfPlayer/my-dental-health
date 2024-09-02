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
        public List<string> roles = new List<string>();

		public void OnActionExecuted(ActionExecutedContext context)
        {
            return;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            int UserId = context.HttpContext.Session.GetJson<int>("UserId");
            if (Login == (UserId != 0))
			{
				if (roles.Count != 0)
				{
					IServiceManager? serviceManager = context.HttpContext.RequestServices.CreateScope().ServiceProvider.GetService<IServiceManager>();

					List<UserRole>? userRoles = serviceManager?.UserService.GetUserRolesWithUserId(UserId);
                    if (userRoles != null && userRoles.Any(ur => roles.Contains(ur.Name)))
                        return;
                }
                else
                    return;
			}
			context.Result = new RedirectToActionResult(RedirectAction, RedirectController, null);
		}
    }
}
