using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdoDotNetDummy.Startup))]
namespace AdoDotNetDummy
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
