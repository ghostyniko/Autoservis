using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Autoservis.MVC.Startup))]
namespace Autoservis.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}