using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InstaSport.Web.Startup))]
namespace InstaSport.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
