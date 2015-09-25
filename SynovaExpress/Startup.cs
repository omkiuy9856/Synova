using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SynovaExpress.Startup))]
namespace SynovaExpress
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
