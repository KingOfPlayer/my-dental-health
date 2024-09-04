using Entity.Models.User;
using Microsoft.AspNetCore.Mvc.Razor;
using Services.Interfaces;

namespace MyDentalHealth.Extentions
{
	public class AuthRazorPage<TModel> : RazorPage<TModel>
	{
		public User? User
		{
			get
			{
				int UserId = base.ViewContext.HttpContext.Session.GetJson<int>("UserId");
				if (UserId != 0)
				{
					IServiceManager? serviceManager = Context.RequestServices.CreateScope().ServiceProvider.GetService<IServiceManager>();
					return serviceManager?.UserService.GetUserWithId(UserId);
				}
				return null;
			}
		}

		public List<UserRole>? Roles
		{
			get
			{
				int UserId = base.ViewContext.HttpContext.Session.GetJson<int>("UserId");
				if (UserId != 0)
				{
					IServiceManager? serviceManager = Context.RequestServices.CreateScope().ServiceProvider.GetService<IServiceManager>();
					return serviceManager?.UserService.GetUserRolesWithUserId(UserId);
				}
				return null;
			}
		}
		public override Task ExecuteAsync()
		{
			throw new NotImplementedException();
		}
	}
}
