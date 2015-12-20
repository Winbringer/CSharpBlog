using Microsoft.Owin;
using Owin;
using ДвижокНовостейЗМ.Models;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;
using ДвижокНовостейЗМ.Models.Identity;

[assembly: OwinStartup(typeof(ДвижокНовостейЗМ.Startup))]

namespace ДвижокНовостейЗМ
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<ApplicationDBContext>(ApplicationDBContext.Create);
            app.CreatePerOwinContext<ApplicationManager>(ApplicationManager.Create);

            // регистрация менеджера ролей
            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }
    }
}