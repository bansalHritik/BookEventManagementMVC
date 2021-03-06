using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebBookEventManager.Startup))]
namespace WebBookEventManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
