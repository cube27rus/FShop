using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FShop.WebUI.Startup))]
namespace FShop.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
