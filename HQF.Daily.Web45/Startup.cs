using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HQF.Daily.Web45.Startup))]
namespace HQF.Daily.Web45
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
