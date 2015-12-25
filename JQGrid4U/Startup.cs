using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JQGrid4U.Startup))]
namespace JQGrid4U
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
