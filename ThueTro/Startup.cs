using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ThueTro.Startup))]
namespace ThueTro
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
