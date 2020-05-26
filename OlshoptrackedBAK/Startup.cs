using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OlshoptrackedBAK.Startup))]
namespace OlshoptrackedBAK
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
