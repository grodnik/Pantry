using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pantry.WebUI.Startup))]
namespace Pantry.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
