using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Wunderlist.Startup))]

namespace Wunderlist
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
