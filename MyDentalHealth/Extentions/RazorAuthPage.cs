using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace MyDentalHealth.Extentions
{
	public class AuthRazorPage<TModel> : RazorPage<TModel>
	{
        public string Auth { get; set; } = "test";
        public override Task ExecuteAsync()
        {
            throw new NotImplementedException();
        }
    }
}
