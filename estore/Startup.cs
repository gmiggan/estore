using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(estore.Startup))]
namespace estore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
