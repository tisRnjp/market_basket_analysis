using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Major_Project.Startup))]
namespace Major_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
