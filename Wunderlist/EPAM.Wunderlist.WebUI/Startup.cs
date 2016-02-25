using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(EPAM.Wunderlist.WebUI.Startup))]

namespace EPAM.Wunderlist.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
