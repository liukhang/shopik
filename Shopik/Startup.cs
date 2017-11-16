using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Shopik.Startup))]
namespace Shopik
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
