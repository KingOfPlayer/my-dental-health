using Entity.Models.User;
using Microsoft.AspNetCore.Mvc.Razor;
using Services.Interfaces;
using System.Text.Json;

namespace MyDentalHealth.Extentions
{
    public static class Metods 
    {
        /*public static User GetAuth(this HttpContext httpContext) {
            IServiceManager serviceManager = httpContext.RequestServices.GetRequiredService<IServiceManager>();
            serviceManager.UserService.
        };*/
        public static void InitSession(this ISession session)
        {
            session.SetInt32("Init",1);
        }
        public static void SetJson<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }
        public static T? GetJson<T>(this ISession session, string key)
        {
            string? data = session.GetString(key);
            return data is null
                ? default(T)
                : JsonSerializer.Deserialize<T>(data);
        }
    }
}
