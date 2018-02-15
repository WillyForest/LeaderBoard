using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LeaderBoard2.Startup))]
namespace LeaderBoard2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
