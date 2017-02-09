using Microsoft.Owin;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using TestApi1.App_Start;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http;

[assembly: OwinStartup(typeof(TestApi1.Startup))]

namespace TestApi1
{
    public partial class Startup
    {
        public static IKernel Kernel { get; set; }
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            HttpConfiguration config = new HttpConfiguration();

            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            Kernel = NinjectConfig.CreateKernel();
            app.UseNinjectMiddleware(() => Kernel);

            //app.UseNinjectWebApi(WebApiConfig.Configure());

        }

        
    }
}
