using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Rocoland.Startup))]
namespace Rocoland
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
