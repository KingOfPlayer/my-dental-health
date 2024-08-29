using Entity.Models.User;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace MyDentalHealth.Extentions
{
	public class AuthRazorPage<TModel> : RazorPage<TModel>
    {
        public User? User => base.ViewContext.HttpContext.Session.GetJson<User>("User");
        public List<UserRole>? Roles => base.ViewContext.HttpContext.Session.GetJson<List<UserRole>>("Roles");
        public override Task ExecuteAsync()
        {
            throw new NotImplementedException();
        }
    }
}
