using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCFilter.Startup))]
namespace MVCFilter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
