using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(webshop_2019.Startup))]
namespace webshop_2019
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
