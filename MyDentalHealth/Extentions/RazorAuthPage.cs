using Entity.Models.User;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Interfaces;
using System.Security.Claims;

namespace MyDentalHealth.Extentions
{
	public class AuthRazorPage<TModel> : RazorPage<TModel>
    {
        /*private readonly IServiceManager? serviceManager;
		public AuthRazorPage(IServiceManager serviceManager)
		{
			this.serviceManager = Context.RequestServices.CreateScope().ServiceProvider.GetService<IServiceManager>();
		}*/

		public User? User
		{
			get
			{
				IServiceManager? serviceManager = Context.RequestServices.CreateScope().ServiceProvider.GetService<IServiceManager>();
				int UserId = base.ViewContext.HttpContext.Session.GetJson<int>("UserId");
				return serviceManager?.UserService.GetUserWithId(UserId);
			}
		}

		public List<UserRole>? Roles
		{
			get
			{
				IServiceManager? serviceManager = Context.RequestServices.CreateScope().ServiceProvider.GetService<IServiceManager>();

				int UserId = base.ViewContext.HttpContext.Session.GetJson<int>("UserId");

				return serviceManager?.UserService.GetUserRolesWithUserId(UserId);
			}
		}
        public override Task ExecuteAsync()
        {
            throw new NotImplementedException();
        }
    }
}
