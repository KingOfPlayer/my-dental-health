using Entity.Models.User;
using Microsoft.AspNetCore.Mvc.Razor;
using Service.Interfaces;

namespace MyDentalHealth.Extentions
{
	public class AuthRazorPage<TModel> : RazorPage<TModel>
	{
		private User? user = null;
		public new User? User
		{
			get
			{
				if (user == null)
				{
					int UserId = base.ViewContext.HttpContext.Session.GetJson<int>("UserId");
					if (UserId != 0)
					{
						IServiceManager? serviceManager = Context.RequestServices.CreateScope().ServiceProvider.GetService<IServiceManager>();
						user = serviceManager?.UserService.GetUserWithId(UserId);
					}
				}
				return user;
			}
		}

		private List<UserRole>? roles = null;
		public List<UserRole>? Roles
		{
			get
			{
				if(roles == null)
				{
					int UserId = base.ViewContext.HttpContext.Session.GetJson<int>("UserId");
					if (UserId != 0)
					{
						IServiceManager? serviceManager = Context.RequestServices.CreateScope().ServiceProvider.GetService<IServiceManager>();
						roles = serviceManager?.UserService.GetUserRolesWithUserId(UserId);
					}
				}
				return roles;
			}
		}
		public override Task ExecuteAsync()
		{
			throw new NotImplementedException();
		}
	}
}
