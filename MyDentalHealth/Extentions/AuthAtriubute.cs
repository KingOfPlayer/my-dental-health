using Entity.Models.User;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MyDentalHealth.Extentions
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class AuthAtriubute : Attribute, IActionFilter
    {
        private readonly string role;

        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
