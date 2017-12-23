using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FlexiFizzBuzzBazz.Startup))]
namespace FlexiFizzBuzzBazz
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
