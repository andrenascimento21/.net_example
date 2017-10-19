using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Riba.Startup))]
namespace Riba
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
