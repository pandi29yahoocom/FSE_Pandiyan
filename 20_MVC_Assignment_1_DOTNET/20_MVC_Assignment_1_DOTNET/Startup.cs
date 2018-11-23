using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_20_MVC_Assignment_1_DOTNET.Startup))]
namespace _20_MVC_Assignment_1_DOTNET
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
