using Entity.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

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
            User? user = context.HttpContext.Session.GetJson<User>("User");
            if (Login == (user != null) )
            {
                if (roles.Count != 0)
                {
                    List<UserRole>? userRoles = context.HttpContext.Session.GetJson<List<UserRole>>("Roles");
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
