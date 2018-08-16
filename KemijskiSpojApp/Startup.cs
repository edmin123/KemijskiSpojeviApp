using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KemijskiSpojApp.Startup))]
namespace KemijskiSpojApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
