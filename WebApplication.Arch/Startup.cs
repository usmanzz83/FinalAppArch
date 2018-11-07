using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebApplication.Arch.Startup))]
namespace WebApplication.Arch
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
